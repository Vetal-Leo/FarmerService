using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Farmer.Controllers.Growing
{
    public partial class GrowingController 
    {
        #region ClierPdfFiles
      
        //Removes blank pdf files.
        public void DeleteEmptyDocumentsFromServer()
        {
            try
            {
                var serverfileslist = GetServerFilesList();
                var basefileslist = GetBaseFilesList();
                var extralist = serverfileslist;
                foreach (var basename in basefileslist)
                    extralist.RemoveAll(item => item == basename);
                foreach (var extraname in extralist)
                    System.IO.File.Delete(Server.MapPath(extraname));
            }
            catch 
            {
                //ignored;
            }
        }

        private List<string> GetServerFilesList()
        {
            var files = Directory.GetFiles(Server.MapPath("/Storefiles/"));
            return files.Select(file => "/Storefiles/" + Path.GetFileName(file)).ToList();
        }

        private IEnumerable<string> GetBaseFilesList()
        {
            var comingfielddocuments = _context.GrowingFieldComingses.Select(d => d.Document).ToList();
            var comingfruitdocuments = _context.GrowingFruitComingses.Select(d => d.Document).ToList();
            var growingchargedocuments = _context.GrowingChargeses.Select(d => d.Document).ToList();
            var fieldprofitdocuments = _context.GrowingFieldProfitses.Select(d => d.Document).ToList();
            var fruitprofitdocuments = _context.GrowingFruitProfitses.Select(d => d.Document).ToList();
            var beecomingdocuments = _context.BeeComingses.Select(d => d.Document).ToList();
            var beehoneydocuments = _context.BeeHoneys.Select(d => d.Document).ToList();
            var breedingchargedocuments = _context.BreedingChargeses.Select(d => d.Document).ToList();
            var breedingcomingdocuments = _context.BreedingComingses.Select(d => d.Document).ToList();
            var breedingdailidocuments = _context.BreedingDailyProfits.Select(d => d.Document).ToList();
            var breedingprofitdocuments = _context.BreedingProfitses.Select(d => d.Document).ToList();
            var fishcomingdocuments = _context.FishComingses.Select(d => d.Document).ToList();
            var fishprofitdocuments = _context.FishProfitses.Select(d => d.Document).ToList();
            var youngbreedingdocuments = _context.YoungBreedings.Select(d => d.Document).ToList();
            comingfielddocuments.AddRange(comingfruitdocuments);
            growingchargedocuments.AddRange(comingfielddocuments);
            fieldprofitdocuments.AddRange(growingchargedocuments);
            fruitprofitdocuments.AddRange(fieldprofitdocuments);
            beecomingdocuments.AddRange(fruitprofitdocuments);
            beehoneydocuments.AddRange(beecomingdocuments);
            breedingchargedocuments.AddRange(beehoneydocuments);
            breedingcomingdocuments.AddRange(breedingchargedocuments);
            breedingdailidocuments.AddRange(breedingcomingdocuments);
            breedingprofitdocuments.AddRange(breedingdailidocuments);
            fishcomingdocuments.AddRange(breedingprofitdocuments);
            fishprofitdocuments.AddRange(fishcomingdocuments);
            youngbreedingdocuments.AddRange(fishprofitdocuments);

            youngbreedingdocuments.RemoveAll(item => item == null);
            return youngbreedingdocuments;
        }
        #endregion

    }
}