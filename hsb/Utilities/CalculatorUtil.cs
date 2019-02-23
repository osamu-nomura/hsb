using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using hsb.Extensions;

namespace hsb.Utilities
{
    #region 【Static Class : CalculatorUtil】
    /// <summary>
    /// 四則計算クラス
    /// </summary>
    public static class CalculatorUtil
    {
        #region ■ Enums
        /// <summary>
        /// トークン種別
        /// </summary>
        private enum TokenType
        {
            Add,    // +演算子
            Sub,    // -演算子
            Mul,    // *演算子
            Div,    // /演算子
            LParen, // 左括弧
            RParen, // 右括弧
            Value   // 値
        }
        #endregion

        #region ■ Inner Class : Token
        /// <summary>
        /// トークンクラス
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class Token<T>
        {
            #region ■ Properties

            #region - TokenType : トークン種別
            /// <summary>
            /// トークン種別
            /// </summary>
            public TokenType TokenType { get; private set; }
            #endregion

            #region - Value : 値
            /// <summary>
            /// 値
            /// </summary>
            public T Value { get; private set; }
            #endregion

            #endregion

            #region ■ Constructor
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="type">トークン種別</param>
            /// <param name="value">値</param>
            public Token(TokenType type, T value)
            {
                TokenType = type;
                Value = value;
            }
            #endregion

            #region ■ Method - FlipSign : 符号を反転させる
            /// <summary>
            /// 符号を反転させる
            /// </summary>
            /// <returns>符号反転させた値</returns>
            public Token<T> FlipSign()
            {
                T newValue = Value;
                if (typeof(T) == typeof(int))
                    newValue = (T)(object)((int)(object)Value * -1);
                if (typeof(T) == typeof(double))
                    newValue = (T)(object)((double)(object)Value * -1.0d);
                if (typeof(T) == typeof(decimal))
                    newValue = (T)(object)((decimal)(object)Value * -1.0m);
                return new Token<T>(this.TokenType, newValue);
            }
            #endregion

            #region ■ Private Static Methods

            #region - IsNum : 数字？
            /// <summary>
            /// 数字
            /// </summary>
            /// <param name="c">文字</param>
            /// <returns>True : 数字 / False : 数字でない</returns>
            private static bool IsNum(char c) => c >= '0' && c < '9';
            #endregion

            #region - GetNumber : 文字列より数値文字列を取得する
            /// <summary>
            /// 文字列より数値文字列を取得する
            /// </summary>
            /// <param name="s">文字列</param>
            /// <param name="startPos">開始位置</param>
            /// <returns>数値文字列と終了位置のタプル</returns>
            private static (string num, int newPos) GetNumber(string s, int startPos)
            {
                var number = "";
                var foundDot = false;
                for (var i = startPos; i < s.Length; i++)
                {
                    if (IsNum(s[i]) || (!foundDot && s[i] == '.'))
                    {
                        number += s[i];
                        if (s[i] == ',')
                            foundDot = true;
                    }
                    else
                        return (number, i);
                }
                return (number, s.Length);
            }
            #endregion

            #region - GetValue : 数値文字列をT型の数値に変換する
            /// <summary>
            /// 数値文字列をT型の数値に変換する
            /// ※ 型変換に失敗した場合は例外を返す
            /// </summary>
            /// <param name="number"><数値文字列/param>
            /// <returns>T型の数値</returns>
            private static T GetValue(string number)
            {
                if (typeof(T) == typeof(int))
                {
                    return (T)(object)int.Parse(number);
                }
                else if (typeof(T) == typeof(double))
                {
                    return (T)(object)double.Parse(number);
                }
                else if (typeof(T) == typeof(decimal))
                {
                    return (T)(object)decimal.Parse(number);
                }
                throw new  TypeAccessException();
            }
            #endregion

            #endregion

            #region ■ Static Methods - Parse : 計算式をパースしてトークンキューを返す。
            /// <summary>
            /// 計算式をパースしてトークンキューを返す。
            /// </summary>
            /// <param name="s">数式</param>
            /// <returns>トークンのキュー</returns>
            public static Queue<Token<T>> Parse(string s)
            {
                if (string.IsNullOrWhiteSpace(s))
                    return null;

                // 余計な空白を除去しておく
                s = s.Replace(" ", "");

                var tokens = new Queue<Token<T>>();
                var i = 0;
                var length = s.Length;
                while (i < length)
                {
                    var c = s[i];
                    switch (c)
                    {
                        case '+':
                            tokens.Enqueue(new Token<T>(TokenType.Add, default(T)));
                            break;
                        case '-':
                            tokens.Enqueue(new Token<T>(TokenType.Sub, default(T)));
                            break;
                        case '*':
                            tokens.Enqueue(new Token<T>(TokenType.Mul, default(T)));
                            break;
                        case '/':
                            tokens.Enqueue(new Token<T>(TokenType.Div, default(T)));
                            break;
                        case '(':
                            tokens.Enqueue(new Token<T>(TokenType.LParen, default(T)));
                            break;
                        case ')':
                            tokens.Enqueue(new Token<T>(TokenType.RParen, default(T)));
                            break;
;                        default:
                            if (IsNum(c))
                            {
                                (var num, var pos) = GetNumber(s, i);
                                tokens.Enqueue(new Token<T>(TokenType.Value, GetValue(num)));
                                i = pos - 1;
                            }
                            else
                                throw new ArgumentException("不正な数式です。");
                            break;
                    }
                    i++;
                }
                return tokens;
            }
            #endregion
        }
        #endregion

        #region ■ Inner Class : ExpressionNode
        private class ExpressionNode<T>
        {
            #region ■ Properties

            #region - Token : トークン
            /// <summary>
            /// トークン
            /// </summary>
            public Token<T> Token { get; private set; } = null;
            #endregion

            #region - Parent : 親
            /// <summary>
            /// 親
            /// </summary>
            public ExpressionNode<T> Parent { get; private set; } = null;
            #endregion

            #region - Left : 左枝
            /// <summary>
            /// 左枝
            /// </summary>
            public ExpressionNode<T> Left { get; private set; } = null;
            #endregion

            #region - Right : 右枝
            /// <summary>
            /// 右枝
            /// </summary>
            public ExpressionNode<T> Right { get; private set; } = null;
            #endregion

            #region - Root : ルートノード
            /// <summary>
            /// ルートノード
            /// </summary>
            public ExpressionNode<T> Root
            {
                get
                {
                    var node = this;
                    while (node.Parent != null)
                        node = node.Parent;
                    return node;
                }
            }
            #endregion

            #endregion

            #region ■ Private Methods

            #region - Add : 加算
            /// <summary>
            /// 加算
            /// </summary>
            /// <param name="n1">値1</param>
            /// <param name="n2">値2</param>
            /// <returns>値1と値2の和</returns>
            private T Add(T n1, T n2)
            {
                if (typeof(T) == typeof(int))
                    return (T)(object)((int)(object)n1 + (int)(object)n2);
                if (typeof(T) == typeof(double))
                    return (T)(object)((double)(object)n1 + (double)(object)n2);
                if (typeof(T) == typeof(decimal))
                    return (T)(object)((decimal)(object)n1 + (decimal)(object)n2);
                return default(T);
            }
            #endregion

            #region - Sub : 減算
            /// <summary>
            /// 減算
            /// </summary>
            /// <param name="n1">値1</param>
            /// <param name="n2">値2</param>
            /// <returns>値1と値2の差</returns>
            private T Sub(T n1, T n2)
            {
                if (typeof(T) == typeof(int))
                    return (T)(object)((int)(object)n1 - (int)(object)n2);
                if (typeof(T) == typeof(double))
                    return (T)(object)((double)(object)n1 - (double)(object)n2);
                if (typeof(T) == typeof(decimal))
                    return (T)(object)((decimal)(object)n1 - (decimal)(object)n2);
                return default(T);
            }
            #endregion

            #region - Mul : 掛け算
            /// <summary>
            /// 掛け算
            /// </summary>
            /// <param name="n1">値1</param>
            /// <param name="n2">値2</param>
            /// <returns>値1と値2の積</returns>
            private T Mul(T n1, T n2)
            {
                if (typeof(T) == typeof(int))
                    return (T)(object)((int)(object)n1 * (int)(object)n2);
                if (typeof(T) == typeof(double))
                    return (T)(object)((double)(object)n1 * (double)(object)n2);
                if (typeof(T) == typeof(decimal))
                    return (T)(object)((decimal)(object)n1 * (decimal)(object)n2);
                return default(T);
            }
            #endregion

            #region - Div : 割り算
            /// <summary>
            /// 割り算
            /// </summary>
            /// <param name="n1">値1</param>
            /// <param name="n2">値2</param>
            /// <returns>値1と値2の商</returns>
            private T Div(T n1, T n2)
            {
                if (typeof(T) == typeof(int))
                    return (T)(object)((int)(object)n1 / (int)(object)n2);
                if (typeof(T) == typeof(double))
                    return (T)(object)((double)(object)n1 / (double)(object)n2);
                if (typeof(T) == typeof(decimal))
                    return (T)(object)((decimal)(object)n1 / (decimal)(object)n2);
                return default(T);
            }
            #endregion

            #endregion

            #region ■ Methods

            #region - InsertParent : トークンを親ノードとして挿入する
            /// <summary>
            /// トークンを親ノードとして挿入する
            /// </summary>
            /// <param name="token">トークン</param>
            /// <returns>挿入されたノード</returns>
            public ExpressionNode<T> InsertParent(Token<T> token)
            {
                var node = new ExpressionNode<T>
                {
                    Token = token,
                    Parent = Parent,
                    Left = this
                };

                if (Parent != null)
                    Parent.Right = node;
                Parent = node;
                return node;
            }
            #endregion

            #region - AddChild : トークンを子ノードとして追加する
            /// <summary>
            /// トークンを子ノードとして追加する
            /// </summary>
            /// <param name="token">トークン</param>
            /// <returns>追加されたノード</returns>
            public ExpressionNode<T> AddChild(Token<T> token)
            {
                Right = new ExpressionNode<T>
                {
                    Token = token,
                    Parent = this
                };
                return Right;
            }
            #endregion

            #region - AddChild : ノードを子ノードとして追加する
            /// <summary>
            /// ノードを子ノードとして追加する
            /// </summary>
            /// <param name="node">ノード</param>
            /// <returns>追加されたノード</returns>
            public ExpressionNode<T> AddChild(ExpressionNode<T> node)
            {
                Right = node;
                node.Parent = this;
                return node;
            }
            #endregion

            #region - Eval : 計算木の評価
            /// <summary>
            /// 計算木の評価
            /// </summary>
            /// <returns>計算結果</returns>
            public T Eval()
            {
                if (Token.TokenType == TokenType.Value)
                    return Token.Value;

                var leftValue = (Left != null) ? Left.Eval() : default(T);
                var rightValue = (Right != null) ? Right.Eval() : default(T);
                switch (Token.TokenType)
                {
                    case TokenType.Add:
                        return Add(leftValue, rightValue);
                    case TokenType.Sub:
                        return Sub(leftValue, rightValue);
                    case TokenType.Mul:
                        return Mul(leftValue, rightValue);
                    case TokenType.Div:
                        return Div(leftValue, rightValue);
                }
                return default(T);
            }
            #endregion

            #endregion

            #region ■ Static Methods : Create
            /// <summary>
            /// ルートノードを生成する
            /// </summary>
            /// <param name="token">トークン</param>
            /// <returns>ノード</returns>
            public static ExpressionNode<T> Create(Token<T> token)
                => new ExpressionNode<T> { Token = token };
            #endregion
        }
        #endregion

        #region ■ Inner Class : Calculator
        /// <summary>
        /// 計算機クラス
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        private class Calculator<T>
        {
            #region ■ Properties

            #region - Tokens : トークンのキュー
            /// <summary>
            /// トークンのキュー
            /// </summary>
            private Queue<Token<T>> Tokens { get; set; }
            #endregion

            #region - ExpressionTree : 計算木
            /// <summary>
            /// 計算木
            /// </summary>
            private ExpressionNode<T> ExpressionTree { get; set; }
            #endregion

            #endregion

            #region ■ Constructor
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="s"></param>
            public Calculator(string s)
            {
                // 数式をパースしてトークンに分解する
                Tokens = Token<T>.Parse(s);

                // 末尾に番兵として右括弧を追加
                Tokens.Enqueue(new Token<T>(TokenType.RParen, default(T)));
                // 計算木を組み立てる
                ExpressionTree = BuildExpression();
            }
            #endregion

            #region ■ Private Method - BuildExpression : 計算木の組み立て
            /// <summary>
            /// 計算木の組み立て
            /// </summary>
            /// <returns>計算木</returns>
            private ExpressionNode<T> BuildExpression()
            {
                var rootToken = Tokens.Dequeue();
                // いきなり閉じ括弧が来た場合は構文エラー
                if (rootToken.TokenType == TokenType.RParen)
                    throw new ApplicationException("構文エラー");
                // いきなり-が来た場合、次のトークンが値なら符号を反転させる
                if (rootToken.TokenType == TokenType.Sub)
                {
                    rootToken = Tokens.Dequeue();
                    if (rootToken.TokenType != TokenType.Value)
                        throw new ApplicationException("構文エラー");
                    rootToken = rootToken.FlipSign();
                }

                var node = (rootToken.TokenType == TokenType.LParen) ? BuildExpression() : ExpressionNode<T>.Create(rootToken);
                while (Tokens.Count > 0)
                {
                    var token = Tokens.Dequeue();
                    switch (token.TokenType)
                    {
                        case TokenType.Add:
                        case TokenType.Sub:
                            // 演算子が連続した場合は構文エラー
                            if (node.Token.TokenType != TokenType.Value && node.Right == null)
                            {
                                // ただし演算子が-で、次のトークンが数値であれば
                                // 負数として処理する
                                var nextToken = Tokens.Dequeue();
                                if (nextToken.TokenType == TokenType.Value)
                                {
                                    node = node.AddChild(nextToken.FlipSign());
                                    break;
                                }
                                else
                                    throw new ApplicationException("構文エラー");
                            }
                            node = (node.Parent ?? node).InsertParent(token);
                            break;
                        case TokenType.Mul:
                        case TokenType.Div:
                            // 演算子が連続した場合は構文エラー
                            if (node.Token.TokenType != TokenType.Value && node.Right == null)
                                throw new ApplicationException("構文エラー");
                            node = node.InsertParent(token);
                            break;
                        case TokenType.Value:
                            // 値が連続すれば構文エラー
                            if (node.Token.TokenType == TokenType.Value)
                                throw new ApplicationException("構文エラー");
                            node = node.AddChild(token);
                            break;
                        case TokenType.LParen:
                            // 開き括弧なら、次の閉じ括弧が出るまで再帰呼び出しする
                            node = node.AddChild(BuildExpression());
                            break;
                        case TokenType.RParen:
                            // 閉じ括弧ならば抜ける
                            return node.Root;
                    }
                }
                return node.Root;
            }
            #endregion

            #region ■ Methods - Calculate : 計算を実行する
            /// <summary>
            /// 計算を実行する
            /// </summary>
            /// <returns>計算結果</returns>
            public T Calculate()
            {
                if (ExpressionTree != null)
                    return ExpressionTree.Eval(); ;
                return default(T);
            }
            #endregion
        }
        #endregion

        #region ■ Static Methods

        #region - Calculate : 数式を評価して計算を実行する
        /// <summary>
        /// 数式を評価して計算を実行する
        /// </summary>
        /// <typeparam name="T">型パラメータ</typeparam>
        /// <param name="s">数式</param>
        /// <returns>計算結果</returns>

        public static T Calculate<T>(string s)
        {
            return new Calculator<T>(s).Calculate();
        }
        #endregion

        #endregion
    }
    #endregion
}
