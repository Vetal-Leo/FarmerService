using System.Collections.Generic;
using System.Linq;

namespace Farmer.Controllers.Growing
{
    public partial class PlantingDatesApiController : BaseApiController
    {
        #region Properties

        public enum ResultType
        {
            Success, PlantingDefection, FloweringDefection, PlantingAndFloweringDefection, Error
        }
        public enum Mn
        {
            NotSet = 0,
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

        public class Result
        {
            public ResultType Rez { get; set; }
            public List<Mn> Plants { get; set; }
            public List<Mn> Flowers { get; set; }
        }
        #endregion


        #region DeterminantMethod

        private static bool DeterminantPlantingOrFlowering(int usermonth, IEnumerable<Mn> allowedlist)
        {
            var month = ConvertToMonthEnum(usermonth);
            return allowedlist.Any(item => month == item);
        }
        private static Mn ConvertToMonthEnum(int usermonth)
        {
            switch (usermonth)
            {
                case 1: return Mn.January;
                case 2: return Mn.February;
                case 3: return Mn.March;
                case 4: return Mn.April;
                case 5: return Mn.May;
                case 6: return Mn.June;
                case 7: return Mn.July;
                case 8: return Mn.August;
                case 9: return Mn.September;
                case 10: return Mn.October;
                case 11: return Mn.November;
                case 12: return Mn.December;
            }
            return Mn.NotSet;
        }

        private static Result Defection(int landingmonth, List<Mn> allowedPlantingList, int floweringmonth, List<Mn> allowedFloweringList)
        {
            if (!DeterminantPlantingOrFlowering(landingmonth, allowedPlantingList) &&
                !DeterminantPlantingOrFlowering(floweringmonth, allowedFloweringList))
                return new Result
                {
                    Rez = ResultType.PlantingAndFloweringDefection,
                    Plants = allowedPlantingList,
                    Flowers = allowedFloweringList
                };
            if (!DeterminantPlantingOrFlowering(landingmonth, allowedPlantingList))
                return new Result { Rez = ResultType.PlantingDefection, Plants = allowedPlantingList };
            return !DeterminantPlantingOrFlowering(floweringmonth, allowedFloweringList) ?
                new Result { Rez = ResultType.FloweringDefection, Flowers = allowedFloweringList } : new Result { Rez = ResultType.Success };
        }
        #endregion
    }
}
