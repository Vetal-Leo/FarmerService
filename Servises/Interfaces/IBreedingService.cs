using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Entities.Breeding;


namespace Servises.Interfaces
{
    public interface IBreedingService : IDisposable
    {

        #region CamelAspect
        List<YoungBreeding> GetCamelYoungs(int userId);
        void AddNewCamelYoung(int userId, FormCollection collection);
        YoungBreeding GetCamelYoungById(int id);
        Task AddNewCamelYoungById(int id, FormCollection collection);
        void DeleteCamelYoungById(int id);
        List<BreedingComings> GetCamelComings(int userId);
        Task AddNewCamelComing(int userId, FormCollection collection);
        BreedingComings GetCamelComingById(int id);
        Task AddNewCamelComingById(int id, FormCollection collection);
        void DeleteCamelComingById(int id);
        List<BreedingCharges> GetCamelCharges(int userId);
        List<string> GetCamelNamesById(int id);
        Task AddNewCamelCharges(int userId, FormCollection collection);
        BreedingCharges GetCamelChargesById(int id);
        Task AddNewCamelChargesById(int id, FormCollection collection);
        void DeleteCamelChargesById(int id);
        List<BreedingDailyProfit> GetCamelDailyProfits(int userId);
        Task AddNewCamelDailyProfits(int userId, FormCollection collection);
        BreedingDailyProfit GetCamelDailyProfitById(int id);
        Task AddNewCamelDailyProfitById(int id, FormCollection collection);
        void DeleteCamelDailyProfitById(int id);
        List<BreedingProfits> GetCamelProfits(int userId);
        BreedingProfits GetCamelProfitById(int id);
        Task AddNewCamelProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetCamelRemindings(int userId);
        Task AddNewCamelReminding(int userId, FormCollection collection);
        BreedingReminder GetCamelRemindingById(int id);
        Task AddNewCamelRemindingById(int id, FormCollection collection);
        void DeleteCamelRemindingById(int id);
        #endregion

        #region GoatAspect
        List<YoungBreeding> GetGoatYoungs(int userId);
        void AddNewGoatYoung(int userId, FormCollection collection);
        YoungBreeding GetGoatYoungById(int id);
        Task AddNewGoatYoungById(int id, FormCollection collection);
        void DeleteGoatYoungById(int id);
        List<BreedingComings> GetGoatComings(int userId);
        Task AddNewGoatComing(int userId, FormCollection collection);
        BreedingComings GetGoatComingById(int id);
        Task AddNewGoatComingById(int id, FormCollection collection);
        void DeleteGoatComingById(int id);
        List<BreedingCharges> GetGoatCharges(int userId);
        List<string> GetGoatNamesById(int id);
        Task AddNewGoatCharges(int userId, FormCollection collection);
        BreedingCharges GetGoatChargesById(int id);
        Task AddNewGoatChargesById(int id, FormCollection collection);
        void DeleteGoatChargesById(int id);
        List<BreedingDailyProfit> GetGoatDailyProfits(int userId);
        Task AddNewGoatDailyProfits(int userId, FormCollection collection);
        BreedingDailyProfit GetGoatDailyProfitById(int id);
        Task AddNewGoatDailyProfitById(int id, FormCollection collection);
        void DeleteGoatDailyProfitById(int id);
        List<BreedingProfits> GetGoatProfits(int userId);
        BreedingProfits GetGoatProfitById(int id);
        Task AddNewGoatProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetGoatRemindings(int userId);
        Task AddNewGoatReminding(int userId, FormCollection collection);
        BreedingReminder GetGoatRemindingById(int id);
        Task AddNewGoatRemindingById(int id, FormCollection collection);
        void DeleteGoatRemindingById(int id);
        #endregion

        #region HorseAspect
        List<YoungBreeding> GetHorseYoungs(int userId);
        void AddNewHorseYoung(int userId, FormCollection collection);
        YoungBreeding GetHorseYoungById(int id);
        Task AddNewHorseYoungById(int id, FormCollection collection);
        void DeleteHorseYoungById(int id);
        List<BreedingComings> GetHorseComings(int userId);
        Task AddNewHorseComing(int userId, FormCollection collection);
        BreedingComings GetHorseComingById(int id);
        Task AddNewHorseComingById(int id, FormCollection collection);
        void DeleteHorseComingById(int id);
        List<BreedingCharges> GetHorseCharges(int userId);
        List<string> GetHorseNamesById(int id);
        Task AddNewHorseCharges(int userId, FormCollection collection);
        BreedingCharges GetHorseChargesById(int id);
        Task AddNewHorseChargesById(int id, FormCollection collection);
        void DeleteHorseChargesById(int id);
        List<BreedingDailyProfit> GetHorseDailyProfits(int userId);
        Task AddNewHorseDailyProfits(int userId, FormCollection collection);
        BreedingDailyProfit GetHorseDailyProfitById(int id);
        Task AddNewHorseDailyProfitById(int id, FormCollection collection);
        void DeleteHorseDailyProfitById(int id);
        List<BreedingProfits> GetHorseProfits(int userId);
        BreedingProfits GetHorseProfitById(int id);
        Task AddNewHorseProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetHorseRemindings(int userId);
        Task AddNewHorseReminding(int userId, FormCollection collection);
        BreedingReminder GetHorseRemindingById(int id);
        Task AddNewHorseRemindingById(int id, FormCollection collection);
        void DeleteHorseRemindingById(int id);
        #endregion

        #region PonyAspect
        List<YoungBreeding> GetPonyYoungs(int userId);
        void AddNewPonyYoung(int userId, FormCollection collection);
        YoungBreeding GetPonyYoungById(int id);
        Task AddNewPonyYoungById(int id, FormCollection collection);
        void DeletePonyYoungById(int id);
        List<BreedingComings> GetPonyComings(int userId);
        Task AddNewPonyComing(int userId, FormCollection collection);
        BreedingComings GetPonyComingById(int id);
        Task AddNewPonyComingById(int id, FormCollection collection);
        void DeletePonyComingById(int id);
        List<BreedingCharges> GetPonyCharges(int userId);
        List<string> GetPonyNamesById(int id);
        Task AddNewPonyCharges(int userId, FormCollection collection);
        BreedingCharges GetPonyChargesById(int id);
        Task AddNewPonyChargesById(int id, FormCollection collection);
        void DeletePonyChargesById(int id);
        List<BreedingDailyProfit> GetPonyDailyProfits(int userId);
        Task AddNewPonyDailyProfits(int userId, FormCollection collection);
        BreedingDailyProfit GetPonyDailyProfitById(int id);
        Task AddNewPonyDailyProfitById(int id, FormCollection collection);
        void DeletePonyDailyProfitById(int id);
        List<BreedingProfits> GetPonyProfits(int userId);
        BreedingProfits GetPonyProfitById(int id);
        Task AddNewPonyProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetPonyRemindings(int userId);
        Task AddNewPonyReminding(int userId, FormCollection collection);
        BreedingReminder GetPonyRemindingById(int id);
        Task AddNewPonyRemindingById(int id, FormCollection collection);
        void DeletePonyRemindingById(int id);
        #endregion

        #region RabbitSkinAspect
        List<BreedingComings> GetRabbitSkinComings(int userId);
        Task AddNewRabbitSkinComing(int userId, FormCollection collection);
        BreedingComings GetRabbitSkinComingById(int id);
        Task AddNewRabbitSkinComingById(int id, FormCollection collection);
        void DeleteRabbitSkinComingById(int id);
        List<BreedingCharges> GetRabbitSkinCharges(int userId);
        List<string> GetRabbitSkinNamesById(int id);
        Task AddNewRabbitSkinCharges(int userId, FormCollection collection);
        BreedingCharges GetRabbitSkinChargesById(int id);
        Task AddNewRabbitSkinChargesById(int id, FormCollection collection);
        void DeleteRabbitSkinChargesById(int id);
        List<BreedingProfits> GetRabbitSkinProfits(int userId);
        BreedingProfits GetRabbitSkinProfitById(int id);
        Task AddNewRabbitSkinProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetRabbitSkinRemindings(int userId);
        Task AddNewRabbitSkinReminding(int userId, FormCollection collection);
        BreedingReminder GetRabbitSkinRemindingById(int id);
        Task AddNewRabbitSkinRemindingById(int id, FormCollection collection);
        void DeleteRabbitSkinRemindingById(int id);
        #endregion

        #region RabbitMeatAspect
        List<BreedingComings> GetRabbitMeatComings(int userId);
        Task AddNewRabbitMeatComing(int userId, FormCollection collection);
        BreedingComings GetRabbitMeatComingById(int id);
        Task AddNewRabbitMeatComingById(int id, FormCollection collection);
        void DeleteRabbitMeatComingById(int id);
        List<BreedingCharges> GetRabbitMeatCharges(int userId);
        List<string> GetRabbitMeatNamesById(int id);
        Task AddNewRabbitMeatCharges(int userId, FormCollection collection);
        BreedingCharges GetRabbitMeatChargesById(int id);
        Task AddNewRabbitMeatChargesById(int id, FormCollection collection);
        void DeleteRabbitMeatChargesById(int id);
        List<BreedingProfits> GetRabbitMeatProfits(int userId);
        BreedingProfits GetRabbitMeatProfitById(int id);
        Task AddNewRabbitMeatProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetRabbitMeatRemindings(int userId);
        Task AddNewRabbitMeatReminding(int userId, FormCollection collection);
        BreedingReminder GetRabbitMeatRemindingById(int id);
        Task AddNewRabbitMeatRemindingById(int id, FormCollection collection);
        void DeleteRabbitMeatRemindingById(int id);
        #endregion


        #region SheepAspect
        List<YoungBreeding> GetSheepYoungs(int userId);
        void AddNewSheepYoung(int userId, FormCollection collection);
        YoungBreeding GetSheepYoungById(int id);
        Task AddNewSheepYoungById(int id, FormCollection collection);
        void DeleteSheepYoungById(int id);
        List<BreedingComings> GetSheepComings(int userId);
        Task AddNewSheepComing(int userId, FormCollection collection);
        BreedingComings GetSheepComingById(int id);
        Task AddNewSheepComingById(int id, FormCollection collection);
        void DeleteSheepComingById(int id);
        List<BreedingCharges> GetSheepCharges(int userId);
        List<string> GetSheepNamesById(int id);
        Task AddNewSheepCharges(int userId, FormCollection collection);
        BreedingCharges GetSheepChargesById(int id);
        Task AddNewSheepChargesById(int id, FormCollection collection);
        void DeleteSheepChargesById(int id);
        List<BreedingDailyProfit> GetSheepDailyProfits(int userId);
        Task AddNewSheepDailyProfits(int userId, FormCollection collection);
        BreedingDailyProfit GetSheepDailyProfitById(int id);
        Task AddNewSheepDailyProfitById(int id, FormCollection collection);
        void DeleteSheepDailyProfitById(int id);
        List<BreedingProfits> GetSheepProfits(int userId);
        BreedingProfits GetSheepProfitById(int id);
        Task AddNewSheepProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetSheepRemindings(int userId);
        Task AddNewSheepReminding(int userId, FormCollection collection);
        BreedingReminder GetSheepRemindingById(int id);
        Task AddNewSheepRemindingById(int id, FormCollection collection);
        void DeleteSheepRemindingById(int id);
        #endregion

        #region HenMeatAspect
        List<BreedingComings> GetHenMeatComings(int userId);
        Task AddNewHenMeatComing(int userId, FormCollection collection);
        BreedingComings GetHenMeatComingById(int id);
        Task AddNewHenMeatComingById(int id, FormCollection collection);
        void DeleteHenMeatComingById(int id);
        List<BreedingCharges> GetHenMeatCharges(int userId);
        List<string> GetHenMeatNamesById(int id);
        Task AddNewHenMeatCharges(int userId, FormCollection collection);
        BreedingCharges GetHenMeatChargesById(int id);
        Task AddNewHenMeatChargesById(int id, FormCollection collection);
        void DeleteHenMeatChargesById(int id);
        List<BreedingDailyProfit> GetHenMeatDailyProfits(int userId);
        Task AddNewHenMeatDailyProfits(int userId, FormCollection collection);
        BreedingDailyProfit GetHenMeatDailyProfitById(int id);
        Task AddNewHenMeatDailyProfitById(int id, FormCollection collection);
        void DeleteHenMeatDailyProfitById(int id);
        List<BreedingProfits> GetHenMeatProfits(int userId);
        BreedingProfits GetHenMeatProfitById(int id);
        Task AddNewHenMeatProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetHenMeatRemindings(int userId);
        Task AddNewHenMeatReminding(int userId, FormCollection collection);
        BreedingReminder GetHenMeatRemindingById(int id);
        Task AddNewHenMeatRemindingById(int id, FormCollection collection);
        void DeleteHenMeatRemindingById(int id);
        #endregion

        #region HenEggAspect
        List<BreedingComings> GetHenEggComings(int userId);
        Task AddNewHenEggComing(int userId, FormCollection collection);
        BreedingComings GetHenEggComingById(int id);
        Task AddNewHenEggComingById(int id, FormCollection collection);
        void DeleteHenEggComingById(int id);
        List<BreedingCharges> GetHenEggCharges(int userId);
        List<string> GetHenEggNamesById(int id);
        Task AddNewHenEggCharges(int userId, FormCollection collection);
        BreedingCharges GetHenEggChargesById(int id);
        Task AddNewHenEggChargesById(int id, FormCollection collection);
        void DeleteHenEggChargesById(int id);
        List<BreedingDailyProfit> GetHenEggDailyProfits(int userId);
        Task AddNewHenEggDailyProfits(int userId, FormCollection collection);
        BreedingDailyProfit GetHenEggDailyProfitById(int id);
        Task AddNewHenEggDailyProfitById(int id, FormCollection collection);
        void DeleteHenEggDailyProfitById(int id);
        List<BreedingProfits> GetHenEggProfits(int userId);
        BreedingProfits GetHenEggProfitById(int id);
        Task AddNewHenEggProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetHenEggRemindings(int userId);
        Task AddNewHenEggReminding(int userId, FormCollection collection);
        BreedingReminder GetHenEggRemindingById(int id);
        Task AddNewHenEggRemindingById(int id, FormCollection collection);
        void DeleteHenEggRemindingById(int id);
        #endregion

        #region GooseAspect
        List<BreedingComings> GetGooseComings(int userId);
        Task AddNewGooseComing(int userId, FormCollection collection);
        BreedingComings GetGooseComingById(int id);
        Task AddNewGooseComingById(int id, FormCollection collection);
        void DeleteGooseComingById(int id);
        List<BreedingCharges> GetGooseCharges(int userId);
        List<string> GetGooseNamesById(int id);
        Task AddNewGooseCharges(int userId, FormCollection collection);
        BreedingCharges GetGooseChargesById(int id);
        Task AddNewGooseChargesById(int id, FormCollection collection);
        void DeleteGooseChargesById(int id);
        List<BreedingDailyProfit> GetGooseDailyProfits(int userId);
        Task AddNewGooseDailyProfits(int userId, FormCollection collection);
        BreedingDailyProfit GetGooseDailyProfitById(int id);
        Task AddNewGooseDailyProfitById(int id, FormCollection collection);
        void DeleteGooseDailyProfitById(int id);
        List<BreedingProfits> GetGooseProfits(int userId);
        BreedingProfits GetGooseProfitById(int id);
        Task AddNewGooseProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetGooseRemindings(int userId);
        Task AddNewGooseReminding(int userId, FormCollection collection);
        BreedingReminder GetGooseRemindingById(int id);
        Task AddNewGooseRemindingById(int id, FormCollection collection);
        void DeleteGooseRemindingById(int id);
        #endregion

        #region QuailAspect
        List<BreedingComings> GetQuailComings(int userId);
        Task AddNewQuailComing(int userId, FormCollection collection);
        BreedingComings GetQuailComingById(int id);
        Task AddNewQuailComingById(int id, FormCollection collection);
        void DeleteQuailComingById(int id);
        List<BreedingCharges> GetQuailCharges(int userId);
        List<string> GetQuailNamesById(int id);
        Task AddNewQuailCharges(int userId, FormCollection collection);
        BreedingCharges GetQuailChargesById(int id);
        Task AddNewQuailChargesById(int id, FormCollection collection);
        void DeleteQuailChargesById(int id);
        List<BreedingDailyProfit> GetQuailDailyProfits(int userId);
        Task AddNewQuailDailyProfits(int userId, FormCollection collection);
        BreedingDailyProfit GetQuailDailyProfitById(int id);
        Task AddNewQuailDailyProfitById(int id, FormCollection collection);
        void DeleteQuailDailyProfitById(int id);
        List<BreedingProfits> GetQuailProfits(int userId);
        BreedingProfits GetQuailProfitById(int id);
        Task AddNewQuailProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetQuailRemindings(int userId);
        Task AddNewQuailReminding(int userId, FormCollection collection);
        BreedingReminder GetQuailRemindingById(int id);
        Task AddNewQuailRemindingById(int id, FormCollection collection);
        void DeleteQuailRemindingById(int id);
        #endregion

        #region BeeAspect     
        List<BeeComings> GetBeeComings(int userId);
        Task AddNewBeeComing(int userId, FormCollection collection);
        BeeComings GetBeeComingById(int id);
        Task AddNewBeeComingById(int id, FormCollection collection);
        void DeleteBeeComingById(int id);
        List<BreedingCharges> GetBeeCharges(int userId);
        List<string> GetBeeNamesById(int id);
        Task AddNewBeeCharges(int userId, FormCollection collection);
        BreedingCharges GetBeeChargesById(int id);
        Task AddNewBeeChargesById(int id, FormCollection collection);
        void DeleteBeeChargesById(int id);
        List<BeeHoney> GetBeeHoneys(int userId);
        Task AddNewBeeHoney(int userId, FormCollection collection);
        BeeHoney GetBeeHoneyById(int id);
        Task AddNewBeeHoneyById(int id, FormCollection collection);
        void DeleteBeeHoneyById(int id);
        List<BreedingReminder> GetBeeRemindings(int userId);
        Task AddNewBeeReminding(int userId, FormCollection collection);
        BreedingReminder GetBeeRemindingById(int id);
        Task AddNewBeeRemindingById(int id, FormCollection collection);
        void DeleteBeeRemindingById(int id);
        #endregion

        #region TeplovyeFishAspect
        List<FishComings> GetTeplovyeFishComings(int userId);
        Task AddNewTeplovyeFishComing(int userId, FormCollection collection);
        FishComings GetTeplovyeFishComingById(int id);
        Task AddNewTeplovyeFishComingById(int id, FormCollection collection);
        void DeleteTeplovyeFishComingById(int id);
        List<BreedingCharges> GetTeplovyeFishCharges(int userId);
        List<string> GetTeplovyeFishNamesById(int id);
        Task AddNewTeplovyeFishCharges(int userId, FormCollection collection);
        BreedingCharges GetTeplovyeFishChargesById(int id);
        Task AddNewTeplovyeFishChargesById(int id, FormCollection collection);
        void DeleteTeplovyeFishChargesById(int id);
        List<FishProfits> GetTeplovyeFishProfits(int userId);
        FishProfits GetTeplovyeFishProfitById(int id);
        Task AddNewTeplovyeFishProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetTeplovyeFishRemindings(int userId);
        Task AddNewTeplovyeFishReminding(int userId, FormCollection collection);
        BreedingReminder GetTeplovyeFishRemindingById(int id);
        Task AddNewTeplovyeFishRemindingById(int id, FormCollection collection);
        void DeleteTeplovyeFishRemindingById(int id);
        #endregion

        #region СoldwaterFishAspect
        List<FishComings> GetСoldwaterFishComings(int userId);
        Task AddNewСoldwaterFishComing(int userId, FormCollection collection);
        FishComings GetСoldwaterFishComingById(int id);
        Task AddNewСoldwaterFishComingById(int id, FormCollection collection);
        void DeleteСoldwaterFishComingById(int id);
        List<BreedingCharges> GetСoldwaterFishCharges(int userId);
        List<string> GetСoldwaterFishNamesById(int id);
        Task AddNewСoldwaterFishCharges(int userId, FormCollection collection);
        BreedingCharges GetСoldwaterFishChargesById(int id);
        Task AddNewСoldwaterFishChargesById(int id, FormCollection collection);
        void DeleteСoldwaterFishChargesById(int id);
        List<FishProfits> GetСoldwaterFishProfits(int userId);
        FishProfits GetСoldwaterFishProfitById(int id);
        Task AddNewСoldwaterFishProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetСoldwaterFishRemindings(int userId);
        Task AddNewСoldwaterFishReminding(int userId, FormCollection collection);
        BreedingReminder GetСoldwaterFishRemindingById(int id);
        Task AddNewСoldwaterFishRemindingById(int id, FormCollection collection);
        void DeleteСoldwaterFishRemindingById(int id);
        #endregion

        #region SwineAspect
        List<YoungBreeding> GetSwineYoungs(int userId);
        void AddNewSwineYoung(int userId, FormCollection collection);
        YoungBreeding GetSwineYoungById(int id);
        Task AddNewSwineYoungById(int id, FormCollection collection);
        void DeleteSwineYoungById(int id);
        List<BreedingComings> GetSwineComings(int userId);
        Task AddNewSwineComing(int userId, FormCollection collection);
        BreedingComings GetSwineComingById(int id);
        Task AddNewSwineComingById(int id, FormCollection collection);
        void DeleteSwineComingById(int id);
        List<BreedingCharges> GetSwineCharges(int userId);
        List<string> GetSwineNamesById(int id);
        Task AddNewSwineCharges(int userId, FormCollection collection);
        BreedingCharges GetSwineChargesById(int id);
        Task AddNewSwineChargesById(int id, FormCollection collection);
        void DeleteSwineChargesById(int id);
        List<BreedingProfits> GetSwineProfits(int userId);
        BreedingProfits GetSwineProfitById(int id);
        Task AddNewSwineProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetSwineRemindings(int userId);
        Task AddNewSwineReminding(int userId, FormCollection collection);
        BreedingReminder GetSwineRemindingById(int id);
        Task AddNewSwineRemindingById(int id, FormCollection collection);
        void DeleteSwineRemindingById(int id);
        #endregion


        #region CattlemeatAspect
        List<YoungBreeding> GetCattlemeatYoungs(int userId);
        void AddNewCattlemeatYoung(int userId, FormCollection collection);
        YoungBreeding GetCattlemeatYoungById(int id);
        Task AddNewCattlemeatYoungById(int id, FormCollection collection);
        void DeleteCattlemeatYoungById(int id);
        List<BreedingComings> GetCattlemeatComings(int userId);
        Task AddNewCattlemeatComing(int userId, FormCollection collection);
        BreedingComings GetCattlemeatComingById(int id);
        Task AddNewCattlemeatComingById(int id, FormCollection collection);
        void DeleteCattlemeatComingById(int id);
        List<BreedingCharges> GetCattlemeatCharges(int userId);
        List<string> GetCattlemeatNamesById(int id);
        Task AddNewCattlemeatCharges(int userId, FormCollection collection);
        BreedingCharges GetCattlemeatChargesById(int id);
        Task AddNewCattlemeatChargesById(int id, FormCollection collection);
        void DeleteCattlemeatChargesById(int id);
        List<BreedingDailyProfit> GetCattlemeatDailyProfits(int userId);
        Task AddNewCattlemeatDailyProfits(int userId, FormCollection collection);
        BreedingDailyProfit GetCattlemeatDailyProfitById(int id);
        Task AddNewCattlemeatDailyProfitById(int id, FormCollection collection);
        void DeleteCattlemeatDailyProfitById(int id);
        List<BreedingProfits> GetCattlemeatProfits(int userId);
        BreedingProfits GetCattlemeatProfitById(int id);
        Task AddNewCattlemeatProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetCattlemeatRemindings(int userId);
        Task AddNewCattlemeatReminding(int userId, FormCollection collection);
        BreedingReminder GetCattlemeatRemindingById(int id);
        Task AddNewCattlemeatRemindingById(int id, FormCollection collection);
        void DeleteCattlemeatRemindingById(int id);
        #endregion

        #region CattlemilkAspect
        List<YoungBreeding> GetCattlemilkYoungs(int userId);
        void AddNewCattlemilkYoung(int userId, FormCollection collection);
        YoungBreeding GetCattlemilkYoungById(int id);
        Task AddNewCattlemilkYoungById(int id, FormCollection collection);
        void DeleteCattlemilkYoungById(int id);
        List<BreedingComings> GetCattlemilkComings(int userId);
        Task AddNewCattlemilkComing(int userId, FormCollection collection);
        BreedingComings GetCattlemilkComingById(int id);
        Task AddNewCattlemilkComingById(int id, FormCollection collection);
        void DeleteCattlemilkComingById(int id);
        List<BreedingCharges> GetCattlemilkCharges(int userId);
        List<string> GetCattlemilkNamesById(int id);
        Task AddNewCattlemilkCharges(int userId, FormCollection collection);
        BreedingCharges GetCattlemilkChargesById(int id);
        Task AddNewCattlemilkChargesById(int id, FormCollection collection);
        void DeleteCattlemilkChargesById(int id);
        List<BreedingDailyProfit> GetCattlemilkDailyProfits(int userId);
        Task AddNewCattlemilkDailyProfits(int userId, FormCollection collection);
        BreedingDailyProfit GetCattlemilkDailyProfitById(int id);
        Task AddNewCattlemilkDailyProfitById(int id, FormCollection collection);
        void DeleteCattlemilkDailyProfitById(int id);
        List<BreedingProfits> GetCattlemilkProfits(int userId);
        BreedingProfits GetCattlemilkProfitById(int id);
        Task AddNewCattlemilkProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetCattlemilkRemindings(int userId);
        Task AddNewCattlemilkReminding(int userId, FormCollection collection);
        BreedingReminder GetCattlemilkRemindingById(int id);
        Task AddNewCattlemilkRemindingById(int id, FormCollection collection);
        void DeleteCattlemilkRemindingById(int id);
        #endregion

        #region CattlemixedAspect
        List<YoungBreeding> GetCattlemixedYoungs(int userId);
        void AddNewCattlemixedYoung(int userId, FormCollection collection);
        YoungBreeding GetCattlemixedYoungById(int id);
        Task AddNewCattlemixedYoungById(int id, FormCollection collection);
        void DeleteCattlemixedYoungById(int id);
        List<BreedingComings> GetCattlemixedComings(int userId);
        Task AddNewCattlemixedComing(int userId, FormCollection collection);
        BreedingComings GetCattlemixedComingById(int id);
        Task AddNewCattlemixedComingById(int id, FormCollection collection);
        void DeleteCattlemixedComingById(int id);
        List<BreedingCharges> GetCattlemixedCharges(int userId);
        List<string> GetCattlemixedNamesById(int id);
        Task AddNewCattlemixedCharges(int userId, FormCollection collection);
        BreedingCharges GetCattlemixedChargesById(int id);
        Task AddNewCattlemixedChargesById(int id, FormCollection collection);
        void DeleteCattlemixedChargesById(int id);
        List<BreedingDailyProfit> GetCattlemixedDailyProfits(int userId);
        Task AddNewCattlemixedDailyProfits(int userId, FormCollection collection);
        BreedingDailyProfit GetCattlemixedDailyProfitById(int id);
        Task AddNewCattlemixedDailyProfitById(int id, FormCollection collection);
        void DeleteCattlemixedDailyProfitById(int id);
        List<BreedingProfits> GetCattlemixedProfits(int userId);
        BreedingProfits GetCattlemixedProfitById(int id);
        Task AddNewCattlemixedProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetCattlemixedRemindings(int userId);
        Task AddNewCattlemixedReminding(int userId, FormCollection collection);
        BreedingReminder GetCattlemixedRemindingById(int id);
        Task AddNewCattlemixedRemindingById(int id, FormCollection collection);
        void DeleteCattlemixedRemindingById(int id);
        #endregion

        #region PinscherdogAspect
        List<BreedingComings> GetPinscherdogComings(int userId);
        Task AddNewPinscherdogComing(int userId, FormCollection collection);
        BreedingComings GetPinscherdogComingById(int id);
        Task AddNewPinscherdogComingById(int id, FormCollection collection);
        void DeletePinscherdogComingById(int id);
        List<BreedingCharges> GetPinscherdogCharges(int userId);
        List<string> GetPinscherdogNamesById(int id);
        Task AddNewPinscherdogCharges(int userId, FormCollection collection);
        BreedingCharges GetPinscherdogChargesById(int id);
        Task AddNewPinscherdogChargesById(int id, FormCollection collection);
        void DeletePinscherdogChargesById(int id);
        List<BreedingProfits> GetPinscherdogProfits(int userId);
        BreedingProfits GetPinscherdogProfitById(int id);
        Task AddNewPinscherdogProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetPinscherdogRemindings(int userId);
        Task AddNewPinscherdogReminding(int userId, FormCollection collection);
        BreedingReminder GetPinscherdogRemindingById(int id);
        Task AddNewPinscherdogRemindingById(int id, FormCollection collection);
        void DeletePinscherdogRemindingById(int id);
        #endregion

        #region HoundsdogAspect
        List<BreedingComings> GetHoundsdogComings(int userId);
        Task AddNewHoundsdogComing(int userId, FormCollection collection);
        BreedingComings GetHoundsdogComingById(int id);
        Task AddNewHoundsdogComingById(int id, FormCollection collection);
        void DeleteHoundsdogComingById(int id);
        List<BreedingCharges> GetHoundsdogCharges(int userId);
        List<string> GetHoundsdogNamesById(int id);
        Task AddNewHoundsdogCharges(int userId, FormCollection collection);
        BreedingCharges GetHoundsdogChargesById(int id);
        Task AddNewHoundsdogChargesById(int id, FormCollection collection);
        void DeleteHoundsdogChargesById(int id);
        List<BreedingProfits> GetHoundsdogProfits(int userId);
        BreedingProfits GetHoundsdogProfitById(int id);
        Task AddNewHoundsdogProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetHoundsdogRemindings(int userId);
        Task AddNewHoundsdogReminding(int userId, FormCollection collection);
        BreedingReminder GetHoundsdogRemindingById(int id);
        Task AddNewHoundsdogRemindingById(int id, FormCollection collection);
        void DeleteHoundsdogRemindingById(int id);
        #endregion

        #region СopsdogAspect
        List<BreedingComings> GetСopsdogComings(int userId);
        Task AddNewСopsdogComing(int userId, FormCollection collection);
        BreedingComings GetСopsdogComingById(int id);
        Task AddNewСopsdogComingById(int id, FormCollection collection);
        void DeleteСopsdogComingById(int id);
        List<BreedingCharges> GetСopsdogCharges(int userId);
        List<string> GetСopsdogNamesById(int id);
        Task AddNewСopsdogCharges(int userId, FormCollection collection);
        BreedingCharges GetСopsdogChargesById(int id);
        Task AddNewСopsdogChargesById(int id, FormCollection collection);
        void DeleteСopsdogChargesById(int id);
        List<BreedingProfits> GetСopsdogProfits(int userId);
        BreedingProfits GetСopsdogProfitById(int id);
        Task AddNewСopsdogProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetСopsdogRemindings(int userId);
        Task AddNewСopsdogReminding(int userId, FormCollection collection);
        BreedingReminder GetСopsdogRemindingById(int id);
        Task AddNewСopsdogRemindingById(int id, FormCollection collection);
        void DeleteСopsdogRemindingById(int id);
        #endregion

        #region BorzoidogAspect
        List<BreedingComings> GetBorzoidogComings(int userId);
        Task AddNewBorzoidogComing(int userId, FormCollection collection);
        BreedingComings GetBorzoidogComingById(int id);
        Task AddNewBorzoidogComingById(int id, FormCollection collection);
        void DeleteBorzoidogComingById(int id);
        List<BreedingCharges> GetBorzoidogCharges(int userId);
        List<string> GetBorzoidogNamesById(int id);
        Task AddNewBorzoidogCharges(int userId, FormCollection collection);
        BreedingCharges GetBorzoidogChargesById(int id);
        Task AddNewBorzoidogChargesById(int id, FormCollection collection);
        void DeleteBorzoidogChargesById(int id);
        List<BreedingProfits> GetBorzoidogProfits(int userId);
        BreedingProfits GetBorzoidogProfitById(int id);
        Task AddNewBorzoidogProfitById(int id, FormCollection collection);
        List<BreedingReminder> GetBorzoidogRemindings(int userId);
        Task AddNewBorzoidogReminding(int userId, FormCollection collection);
        BreedingReminder GetBorzoidogRemindingById(int id);
        Task AddNewBorzoidogRemindingById(int id, FormCollection collection);
        void DeleteBorzoidogRemindingById(int id);
        #endregion

    }
}
