using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DML
{
    public enum FilterOperator
    {
        /// <summary>مساوی</summary>
        Equal = 0,
        /// <summary>نامساوی</summary>
        NotEqual = 1,
        /// <summary>بزرگتر</summary>
        Greater = 2,
        /// <summary>بزرگتر مساوی</summary>
        GreaterEqual = 3,
        /// <summary>کمتر</summary>
        Lower = 4,
        /// <summary>کمتر مساوی</summary>
        LowerEqual = 5,
        /// <summary>Like '%@var%'</summary>
        Like = 6,
        /// <summary>
        /// هیچ فیلتری اعمال نشود
        /// </summary>
        Nothing = 7,
        /// <summary>
        /// Like '%@var'
        /// </summary>
        PreLike=8,
        /// <summary>
        /// Like'@var%'
        /// </summary>
        PostLike=9,
        /// <summary>
        /// تساوی رشته ای
        /// </summary>
        EqualString = 10,
        /// <summary>
        /// عدم تساوی رشته ای
        /// </summary>
        NotEqualString = 11,
        /// <summary>
        /// رشته کوچکتر از
        /// </summary>
        GreaterString = 12,
        /// <summary>
        /// رشته کوچکتر مساوی
        /// </summary>
        GreaterEqualString = 13,
        /// <summary>
        /// رشته بزرگتر از
        /// </summary>
        LowerString = 14,
        /// <summary>
        /// رشته بزرگتر مساوی
        /// </summary>
        LowerEqualString = 15
    }
    public static class FilterOperatorValue
    {
        public static int GetValue(FilterOperator op)
        {
            switch (op)
            {
                case FilterOperator.Equal:
                    return 0;
                case FilterOperator.NotEqual:
                    return 1;
                case FilterOperator.Greater:
                    return 2;
                case FilterOperator.GreaterEqual:
                    return 3;
                case FilterOperator.Lower:
                    return 4;
                case FilterOperator.LowerEqual:
                    return 5;
                case FilterOperator.Like:
                    return 6;
                case FilterOperator.Nothing:
                    return 7;
                case FilterOperator.PreLike:
                    return 8;
                case FilterOperator.PostLike:
                    return 9;
                case FilterOperator.EqualString:
                    return 10;
                case FilterOperator.NotEqualString:
                    return 11;
                case FilterOperator.GreaterString:
                    return 12;
                case FilterOperator.GreaterEqualString:
                    return 13;
                case FilterOperator.LowerString:
                    return 14;
                case FilterOperator.LowerEqualString:
                    return 15;
            }
            return 7;
        }
    }
}
