using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Entities.Growing;

namespace Servises.Interfaces
{
    public  interface IGrowingService : IDisposable
    {
        #region BreadCulture
        List<GrowingFieldComings> GetBreadComings(int userId);
        Task AddNewGrowing(int userId, FormCollection collection);
        GrowingFieldComings GetBreadComingById(int id);
        Task AddNewGrowingById(int id, FormCollection collection);
        void DeleteGrowingById(int id);
        List<GrowingCharges> GetBreadCharges(int userId);
        List<string> GetBreadNamesById(int id);
        Task AddNewBreadCharges(int id, FormCollection collection);
        GrowingCharges GetBreadChargesById(int id);
        Task AddNewBreadChargesById(int id, FormCollection collection);
        void DeleteBreadChargesById(int id);
        List<GrowingFieldProfits> GetBreadProfits(int userId);
        GrowingFieldProfits GetBreadProfitById(int id);
        Task AddNewBreadProfitById(int id, FormCollection collection);
        #endregion

        #region LeguminousCulture
        List<GrowingFieldComings> GetLeguminousComings(int userId);
        Task AddNewLeguminous(int userId, FormCollection collection);
        GrowingFieldComings GetLeguminousComingById(int id);
        Task AddNewLeguminousById(int id, FormCollection collection);
        void DeleteLeguminousById(int id);
        List<GrowingCharges> GetLeguminousCharges(int userId);
        List<string> GetLeguminousNamesById(int id);
        Task AddNewLeguminousCharges(int userId, FormCollection collection);
        GrowingCharges GetLeguminousChargesById(int id);
        Task AddNewLeguminousChargesById(int id, FormCollection collection);
        void DeleteLeguminousChargesById(int id);
        List<GrowingFieldProfits> GetLeguminousProfits(int userId);
        GrowingFieldProfits GetLeguminousProfitById(int id);
        Task AddNewLeguminousProfitById(int id, FormCollection collection);
        #endregion

        #region TuberCulture
        List<GrowingFieldComings> GetTuberComings(int userId);
        Task AddNewTuber(int userId, FormCollection collection);
        GrowingFieldComings GetTuberComingById(int id);
        Task AddNewTuberById(int id, FormCollection collection);
        void DeleteTuberById(int id);
        List<GrowingCharges> GetTuberCharges(int userId);
        List<string> GetTuberNamesById(int id);
        Task AddNewTuberCharges(int userId, FormCollection collection);
        GrowingCharges GetTuberChargesById(int id);
        Task AddNewTuberChargesById(int id, FormCollection collection);
        void DeleteTuberChargesById(int id);
        List<GrowingFieldProfits> GetTuberProfits(int userId);
        GrowingFieldProfits GetTuberProfitById(int id);
        Task AddNewTuberProfitById(int id, FormCollection collection);
        #endregion

        #region SpicyCulture
        List<GrowingFieldComings> GetSpicyComings(int userId);
        Task AddNewSpicy(int userId, FormCollection collection);
        GrowingFieldComings GetSpicyComingById(int id);
        Task AddNewSpicyById(int id, FormCollection collection);
        void DeleteSpicyById(int id);
        List<GrowingCharges> GetSpicyCharges(int userId);
        List<string> GetSpicyNamesById(int id);
        Task AddNewSpicyCharges(int userId, FormCollection collection);
        GrowingCharges GetSpicyChargesById(int id);
        Task AddNewSpicyChargesById(int id, FormCollection collection);
        void DeleteSpicyChargesById(int id);
        List<GrowingFieldProfits> GetSpicyProfits(int userId);
        GrowingFieldProfits GetSpicyProfitById(int id);
        Task AddNewSpicyProfitById(int id, FormCollection collection);
        #endregion

        #region MelonCulture
        List<GrowingFieldComings> GetMelonComings(int userId);
        Task AddNewMelon(int userId, FormCollection collection);
        GrowingFieldComings GetMelonComingById(int id);
        Task AddNewMelonById(int id, FormCollection collection);
        void DeleteMelonById(int id);
        List<GrowingCharges> GetMelonCharges(int userId);
        List<string> GetMelonNamesById(int id);
        Task AddNewMelonCharges(int userId, FormCollection collection);
        GrowingCharges GetMelonChargesById(int id);
        Task AddNewMelonChargesById(int id, FormCollection collection);
        void DeleteMelonChargesById(int id);
        List<GrowingFieldProfits> GetMelonProfits(int userId);
        GrowingFieldProfits GetMelonProfitById(int id);
        Task AddNewMelonProfitById(int id, FormCollection collection);
        #endregion

        #region OliveCulture
        List<GrowingFieldComings> GetOliveComings(int userId);
        Task AddNewOlive(int userId, FormCollection collection);
        GrowingFieldComings GetOliveComingById(int id);
        Task AddNewOliveById(int id, FormCollection collection);
        void DeleteOliveById(int id);
        List<GrowingCharges> GetOliveCharges(int userId);
        List<string> GetOliveNamesById(int id);
        Task AddNewOliveCharges(int userId, FormCollection collection);
        GrowingCharges GetOliveChargesById(int id);
        Task AddNewOliveChargesById(int id, FormCollection collection);
        void DeleteOliveChargesById(int id);
        List<GrowingFieldProfits> GetOliveProfits(int userId);
        GrowingFieldProfits GetOliveProfitById(int id);
        Task AddNewOliveProfitById(int id, FormCollection collection);
        #endregion


        #region SilageCulture
        List<GrowingFieldComings> GetSilageComings(int userId);
        Task AddNewSilage(int userId, FormCollection collection);
        GrowingFieldComings GetSilageComingById(int id);
        Task AddNewSilageById(int id, FormCollection collection);
        void DeleteSilageById(int id);
        List<GrowingCharges> GetSilageCharges(int userId);
        List<string> GetSilageNamesById(int id);
        Task AddNewSilageCharges(int userId, FormCollection collection);
        GrowingCharges GetSilageChargesById(int id);
        Task AddNewSilageChargesById(int id, FormCollection collection);
        void DeleteSilageChargesById(int id);
        List<GrowingFieldProfits> GetSilageProfits(int userId);
        GrowingFieldProfits GetSilageProfitById(int id);
        Task AddNewSilageProfitById(int id, FormCollection collection);
        #endregion

        #region FodderCulture
        List<GrowingFieldComings> GetFodderComings(int userId);
        Task AddNewFodder(int userId, FormCollection collection);
        GrowingFieldComings GetFodderComingById(int id);
        Task AddNewFodderById(int id, FormCollection collection);
        void DeleteFodderById(int id);
        List<GrowingCharges> GetFodderCharges(int userId);
        List<string> GetFodderNamesById(int id);
        Task AddNewFodderCharges(int userId, FormCollection collection);
        GrowingCharges GetFodderChargesById(int id);
        Task AddNewFodderChargesById(int id, FormCollection collection);
        void DeleteFodderChargesById(int id);
        List<GrowingFieldProfits> GetFodderProfits(int userId);
        GrowingFieldProfits GetFodderProfitById(int id);
        Task AddNewFodderProfitById(int id, FormCollection collection);
        #endregion

        #region ForageCulture
        List<GrowingFieldComings> GetForageComings(int userId);
        Task AddNewForage(int userId, FormCollection collection);
        GrowingFieldComings GetForageComingById(int id);
        Task AddNewForageById(int id, FormCollection collection);
        void DeleteForageById(int id);
        List<GrowingCharges> GetForageCharges(int userId);
        List<string> GetForageNamesById(int id);
        Task AddNewForageCharges(int userId, FormCollection collection);
        GrowingCharges GetForageChargesById(int id);
        Task AddNewForageChargesById(int id, FormCollection collection);
        void DeleteForageChargesById(int id);
        List<GrowingFieldProfits> GetForageProfits(int userId);
        GrowingFieldProfits GetForageProfitById(int id);
        Task AddNewForageProfitById(int id, FormCollection collection);
        #endregion

        #region BergamotCulture
        List<GrowingFruitComings> GetBergamotComings(int userId);
        Task AddNewBergamot(int userId, FormCollection collection);
        GrowingFruitComings GetBergamotComingById(int id);
        Task AddNewBergamotById(int id, FormCollection collection);
        void DeleteBergamotById(int id);
        List<GrowingCharges> GetBergamotCharges(int userId);
        List<string> GetBergamotNamesById(int id);
        Task AddNewBergamotCharges(int userId, FormCollection collection);
        GrowingCharges GetBergamotChargesById(int id);
        Task AddNewBergamotChargesById(int id, FormCollection collection);
        void DeleteBergamotChargesById(int id);
        List<GrowingFruitProfits> GetBergamotProfits(int userId);
        GrowingFruitProfits GetBergamotProfitById(int id);
        Task AddNewBergamotProfitById(int id, FormCollection collection);
        #endregion

        #region KepelCulture
        List<GrowingFruitComings> GetKepelComings(int userId);
        Task AddNewKepel(int userId, FormCollection collection);
        GrowingFruitComings GetKepelComingById(int id);
        Task AddNewKepelById(int id, FormCollection collection);
        void DeleteKepelById(int id);
        List<GrowingCharges> GetKepelCharges(int userId);
        List<string> GetKepelNamesById(int id);
        Task AddNewKepelCharges(int userId, FormCollection collection);
        GrowingCharges GetKepelChargesById(int id);
        Task AddNewKepelChargesById(int id, FormCollection collection);
        void DeleteKepelChargesById(int id);
        List<GrowingFruitProfits> GetKepelProfits(int userId);
        GrowingFruitProfits GetKepelProfitById(int id);
        Task AddNewKepelProfitById(int id, FormCollection collection);
        #endregion

        #region FinikCulture
        List<GrowingFruitComings> GetFinikComings(int userId);
        Task AddNewFinik(int userId, FormCollection collection);
        GrowingFruitComings GetFinikComingById(int id);
        Task AddNewFinikById(int id, FormCollection collection);
        void DeleteFinikById(int id);
        List<GrowingCharges> GetFinikCharges(int userId);
        List<string> GetFinikNamesById(int id);
        Task AddNewFinikCharges(int userId, FormCollection collection);
        GrowingCharges GetFinikChargesById(int id);
        Task AddNewFinikChargesById(int id, FormCollection collection);
        void DeleteFinikChargesById(int id);
        List<GrowingFruitProfits> GetFinikProfits(int userId);
        GrowingFruitProfits GetFinikProfitById(int id);
        Task AddNewFinikProfitById(int id, FormCollection collection);
        #endregion

        #region CrataeguCulture
        List<GrowingFruitComings> GetCrataeguComings(int userId);
        Task AddNewCrataegu(int userId, FormCollection collection);
        GrowingFruitComings GetCrataeguComingById(int id);
        Task AddNewCrataeguById(int id, FormCollection collection);
        void DeleteCrataeguById(int id);
        List<GrowingCharges> GetCrataeguCharges(int userId);
        List<string> GetCrataeguNamesById(int id);
        Task AddNewCrataeguCharges(int userId, FormCollection collection);
        GrowingCharges GetCrataeguChargesById(int id);
        Task AddNewCrataeguChargesById(int id, FormCollection collection);
        void DeleteCrataeguChargesById(int id);
        List<GrowingFruitProfits> GetCrataeguProfits(int userId);
        GrowingFruitProfits GetCrataeguProfitById(int id);
        Task AddNewCrataeguProfitById(int id, FormCollection collection);
        #endregion

        #region TernCulture
        List<GrowingFruitComings> GetTernComings(int userId);
        Task AddNewTern(int userId, FormCollection collection);
        GrowingFruitComings GetTernComingById(int id);
        Task AddNewTernById(int id, FormCollection collection);
        void DeleteTernById(int id);
        List<GrowingCharges> GetTernCharges(int userId);
        List<string> GetTernNamesById(int id);
        Task AddNewTernCharges(int userId, FormCollection collection);
        GrowingCharges GetTernChargesById(int id);
        Task AddNewTernChargesById(int id, FormCollection collection);
        void DeleteTernChargesById(int id);
        List<GrowingFruitProfits> GetTernProfits(int userId);
        GrowingFruitProfits GetTernProfitById(int id);
        Task AddNewTernProfitById(int id, FormCollection collection);
        #endregion

        #region StrawberryCulture
        List<GrowingFruitComings> GetStrawberryComings(int userId);
        Task AddNewStrawberry(int userId, FormCollection collection);
        GrowingFruitComings GetStrawberryComingById(int id);
        Task AddNewStrawberryById(int id, FormCollection collection);
        void DeleteStrawberryById(int id);
        List<GrowingCharges> GetStrawberryCharges(int userId);
        List<string> GetStrawberryNamesById(int id);
        Task AddNewStrawberryCharges(int userId, FormCollection collection);
        GrowingCharges GetStrawberryChargesById(int id);
        Task AddNewStrawberryChargesById(int id, FormCollection collection);
        void DeleteStrawberryChargesById(int id);
        List<GrowingFruitProfits> GetStrawberryProfits(int userId);
        GrowingFruitProfits GetStrawberryProfitById(int id);
        Task AddNewStrawberryProfitById(int id, FormCollection collection);
        #endregion

    }
}
