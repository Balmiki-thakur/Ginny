using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Rules
{
    public enum ComparerIntEnum
    {
        Equal,
        NotEqual,
        GreaterThan,
        LessThan
    }

    public enum ComparerEnum
    {
        Equal,
        NotEqual
    }

    public enum CompareObjectEnum
    {
        ReferenceEqual,
        ReferenceNotEqual,
        ValueEquals
    }

    public class ComparerStringRule
    {
        private string _errorMessage = "String Comparions failed !!!";
        private string _comparer = string.Empty;
        private ComparerEnum _operation;

        public ComparerStringRule(string comparer, ComparerEnum operation)
        {
            _comparer = comparer;
            _operation = operation;
        }
        public ComparerStringRule(string comparer, string ErrorMessage, ComparerEnum operation)
        {
            _comparer = comparer;
            _operation = operation;
            _errorMessage = ErrorMessage;
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
        public string Comparer
        {
            get { return _comparer; }
            set { _comparer = value; }
        }
        public ComparerEnum Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
        public bool Validate(string value, string Comparer, string ErrorMessage, ComparerEnum operation)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (!string.IsNullOrEmpty(Comparer))
                {
                    switch (operation)
                    {
                        case ComparerEnum.Equal:
                            if (value.Trim().ToUpper() != Comparer.Trim().ToUpper())
                            {

                                return false;
                            }
                            break;
                        case ComparerEnum.NotEqual:
                            if (value.Trim().ToUpper() == Comparer.Trim().ToUpper())
                            {

                                return false;
                            }
                            break;
                        default:
                            if (value.Trim().ToUpper() != Comparer.Trim().ToUpper())
                            {

                                return false;
                            }
                            break;
                    }
                }
            }
            return true;
        }


    }
}
