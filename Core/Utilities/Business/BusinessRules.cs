using System.Collections.Generic;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult
            Run(params IResult[] logics) //params keywordu IResult türünden istedigimiz kadar deger vermemizi saglar
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic; //Kurallara uymayanlari geri döndür
                }
            }

            return null;
        }

        #region II.YOL
        //public static List<IResult> Run(params IResult[] logics)
        //{
        //    List<IResult> erroResults = new List<IResult>();
        //    foreach (var logic in logics)
        //    {
        //        if (!logic.Success)
        //        {
        //            erroResults.Add(logic);
        //        }
        //    }

        //    return null;
        //}
        #endregion
    }
}