using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Farmer.Controllers.Growing
{
    public partial class PlantingDatesApiController
    {
        #region PlantingMethods

        [HttpPost]
        public Result IsPlantCultureForFruit(string culturetype, string landingdate, string floweringdate)
        {
            DateTime result;
            DateTime result1;
            List<Mn> allowedPlantingList;
            List<Mn> allowedFloweringList;
          
            if (string.IsNullOrEmpty(culturetype) || string.IsNullOrEmpty(landingdate) || string.IsNullOrEmpty(floweringdate) ||
                !DateTime.TryParse(landingdate, out result) || !DateTime.TryParse(floweringdate, out result1))
                return new Result { Rez = ResultType.Error};

            var landingmonth = DateTime.Parse(landingdate).Month;
            var floweringmonth = DateTime.Parse(floweringdate).Month;
            switch (culturetype)
            {
                case "Абрикос":
                    allowedPlantingList = new List<Mn> { Mn.October, Mn.November, Mn.April, Mn.May };
                    allowedFloweringList = new List<Mn> { Mn.March, Mn.April };
                    return Defection(landingmonth, allowedPlantingList, floweringmonth, allowedFloweringList);
                case "Абрикос японский":
                    allowedPlantingList = new List<Mn> { Mn.October, Mn.November, Mn.April, Mn.May };
                    allowedFloweringList = new List<Mn> { Mn.February };
                    return Defection(landingmonth, allowedPlantingList, floweringmonth, allowedFloweringList);
                case "Авара":         
                    return new Result { Rez = ResultType.Success};
                case "Авокадо":
                    allowedPlantingList = new List<Mn> { Mn.March, Mn.April, Mn.April, Mn.May };
                    allowedFloweringList = new List<Mn> { Mn.October, Mn.November, Mn.December, Mn.January, Mn.February, Mn.March, Mn.April, Mn.May, Mn.June };
                    return Defection(landingmonth, allowedPlantingList, floweringmonth, allowedFloweringList);
                case "Азимина трёхлопастная":
                    allowedPlantingList = new List<Mn> { Mn.March, Mn.April, Mn.May, Mn.September, Mn.October, Mn.November};
                    allowedFloweringList = new List<Mn> { Mn.April, Mn.May };
                    return Defection(landingmonth, allowedPlantingList, floweringmonth, allowedFloweringList);
                case "Айва":
                    allowedPlantingList = new List<Mn> { Mn.October, Mn.November, Mn.March, Mn.April, Mn.May };
                    allowedFloweringList = new List<Mn> { Mn.May, Mn.June };
                    return Defection(landingmonth, allowedPlantingList, floweringmonth, allowedFloweringList);
                case "Айва китайская":
                    allowedPlantingList = new List<Mn> { Mn.October, Mn.November, Mn.March, Mn.April };
                    allowedFloweringList = new List<Mn> { Mn.April, Mn.May };
                    return Defection(landingmonth, allowedPlantingList, floweringmonth, allowedFloweringList);
                case "Алыча":
                    allowedPlantingList = new List<Mn> { Mn.March, Mn.April, Mn.September};
                    allowedFloweringList = new List<Mn> { Mn.May };
                    return Defection(landingmonth, allowedPlantingList, floweringmonth, allowedFloweringList);

                    //TODO:
            }

            return new Result {Rez = ResultType.Success};
        }

    
        
        #endregion
    }
}

                    //case "":
                    //allowedPlantingList = new List<Mn> { Mn.March, Mn.April, Mn.May, Mn.September, Mn.October, Mn.November };
                    //allowedFloweringList = new List<Mn> { Mn.April, Mn.May };
                    //return Defection(landingmonth, allowedPlantingList, floweringmonth, allowedFloweringList);