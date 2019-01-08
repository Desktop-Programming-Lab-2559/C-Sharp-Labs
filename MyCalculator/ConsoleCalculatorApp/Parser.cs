using System;
using System.Collections.Generic;

namespace ConsoleCalculatorApp
{
    enum Tokens { UNDEF, NUMBER, OPERATOR }

    enum Errors { DIVBYZERO, NOEXPRESSION, SERROR, PARENS }

    // Recursive descent parser
    public class Parser
    {
        string _expression;
        string _token;
        Tokens tokenType;
        int globalIndex = 0;

        public Parser()
        {
            _expression = string.Empty;
        }

        public double Evaluate(string exp)
        {
            double result = 0.0;
            _expression = exp;

            GetToken();

            if (string.IsNullOrEmpty(_token))
            {
                Error(Errors.NOEXPRESSION);
                return result;
            }

            Evaluate2(ref result);
            if (string.IsNullOrEmpty(_token))
                Error(Errors.SERROR);

            return result;
        }

        private void Evaluate2(ref double result)
        {
            char operation;
            double tmp = 0.0;

            Evaluate3(ref result);

            while ((operation = _token[0]) == '+' || operation =='-')
            {
                GetToken();
                Evaluate3(ref tmp);
                switch (operation)
                {
                    case '-': result -= tmp; break;
                    case '+': result += tmp; break;
                }
            }
        }

        private void Evaluate3(ref double result)
        {
            char operation;
            double tmp = 0.0;

            Evaluate4(ref result);

            while ((operation = _token[0]) == '*' || operation == '/' || operation == '%')
            {
                GetToken();
                Evaluate4(ref tmp);
                switch (operation)
                {
                    case '*': result *= tmp; break;
                    case '/': result /= tmp; break;
                    case '%': result = (int)result % (int)tmp; break;
                }
            }
        }

        private void Evaluate4(ref double result)
        {
            double tmp = 0.0, tmp1;
            int t = 0;
            Evaluate5(ref result);
            if(_token[0] == '^')
            {
                GetToken();
                Evaluate4(ref tmp);
                tmp1 = result;
                if (tmp == 0.0)
                {
                    result = 1.0;
                    return;
                }
                for (t = (int)tmp - 1;  t > 0; --t)
                {
                    result *= tmp1;
                }
            }
        }

        private void Evaluate5(ref double result)
        {
            char operation = ' ';
            if((tokenType == Tokens.OPERATOR) && (_token[0] == '+' || _token[0] == '-'))
            {
                operation = _token[0];
                GetToken();
            }
            Evaluate6(ref result);
            if (operation == '-')
                result = -result;
        }

        private void Evaluate6(ref double result)
        {
            if(_token[0] == '(')
            {
                GetToken();
                Evaluate2(ref result);
                if (_token[0] != ')')
                    Error(Errors.PARENS);
                GetToken();
            }
            else
            {
                switch(tokenType)
                {
                    case Tokens.NUMBER: result = Convert.ToDouble(_token); GetToken(); break;
                }
            }
        }

        private void Error(Errors nOEXPRESSION)
        {
            string[] errors = { "Syntax Error", "Unbalances Parentheses", "No Expression", "Div By Zero" };
            Console.WriteLine($"{errors[(int)nOEXPRESSION]}");
        }

        private void GetToken()
        {
            List<char> tmp = new List<char>();
            tokenType = Tokens.UNDEF;

            if (string.IsNullOrEmpty(_expression))
                return;

            for (int i = globalIndex; i < _expression.Length; i++, globalIndex++)
            {
                if(!char.IsWhiteSpace(_expression[i]))
                {
                    if("+-*/%^=()".IndexOf(_expression[i]) != -1)
                    {
                        tmp.Add(_expression[i++]);
                        _token = new string(tmp.ToArray());
                        tokenType = Tokens.OPERATOR;
                        globalIndex++;
                        break;
                    }
                    else if (char.IsDigit(_expression[i]))
                    {
                        while (" +-*/%^=()".IndexOf(_expression[i]) == -1)
                        {
                            tmp.Add(_expression[i++]);
                            globalIndex++;
                            if (i >= _expression.Length)
                                break;
                        }
                        _token = new string(tmp.ToArray());
                        tokenType = Tokens.NUMBER;
                        break;
                    }
                }
            }
        }
    }
}
