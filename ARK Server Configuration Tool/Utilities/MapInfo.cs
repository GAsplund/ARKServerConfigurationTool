using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArkSavegameToolkitNet.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ARK_Server_Configuration_Tool.Utilities
{
    class MapInfo
    {
        ArkGameData GameData;
        

        public ArkWildCreature[] GetWildDinosInMap(string Path)
        {
            GameData = new ArkGameData(@Path, loadOnlyPropertiesInDomain: true);

            if (GameData.Update(CancellationToken.None, deferApplyNewData: true)?.Success == true)
            {
                GameData.ApplyPreviousUpdate();
            }
            return GameData.WildCreatures;
        }

        public ArkTamedCreature[] GetTamedDinosInMap(string Path)
        {
            GameData = new ArkGameData(@Path, loadOnlyPropertiesInDomain: true);

            if (GameData.Update(CancellationToken.None, deferApplyNewData: true)?.Success == true)
            {
                GameData.ApplyPreviousUpdate();
            }
            return GameData.TamedCreatures;
        }

        public async Task DisplayInfo(string DinoName)
        {
            MainForm MainForm_Control = System.Windows.Forms.Application.OpenForms.OfType<MainForm>().First();
            MainForm_Control.MapInfoDinoListDataGridView.Rows.Clear();
            // Variable GameData can be called again, since it it already defined when the server data is loaded
            var aliases = GlobalVariables.DinoAliases.First.First.Where(x => x.First.ToString().Equals(DinoName) == true).ToArray();
            string DinoClass = aliases[0][1].ToString();
            try
            {
                var calledDinos = GameData.WildCreatures.Where(x => x.ClassName?.Equals(DinoClass) == true).ToArray();
                foreach (ArkWildCreature dino in calledDinos)
                {
                    string[] DinoInfoRow = { dino.Gender.ToString(), dino.BaseLevel.ToString(), dino.Location.Latitude.ToString(), dino.Location.Longitude.ToString(), dino.IsTameable.ToString() };
                    MainForm_Control.MapInfoDinoListDataGridView.Rows.Add(DinoInfoRow);
                }
            } catch
            {

            }
        }

        public async Task AddWildCreaturesToList(ArkWildCreature[] WildCreatures)
        {
            List<string> WildCreaturesNoDupes = new List<string>();
            foreach (ArkWildCreature WildCreature in WildCreatures)
            {
                WildCreaturesNoDupes.Add(WildCreature.ClassName);
            }
            WildCreaturesNoDupes = WildCreaturesNoDupes.Distinct().ToList();
            MainForm MainForm_Control = System.Windows.Forms.Application.OpenForms.OfType<MainForm>().First();
            MainForm_Control.MapInfoDinoSelectionComboBox.Items.Clear();
            foreach (string wildCreature in WildCreaturesNoDupes)
            {
                var aliases = GlobalVariables.DinoAliases.First.First.Where(x => x[1].ToString().Equals(wildCreature) == true).ToArray();
                string DinoName = aliases[0][0].ToString();
                MainForm_Control.MapInfoDinoSelectionComboBox.Items.Add(DinoName);
            }
        }

        public async Task AddTamedCreaturesToList(ArkTamedCreature[] TamedCreatures)
        {
            List<string> WildCreaturesNoDupes = new List<string>();
            foreach (ArkTamedCreature TamedCreature in TamedCreatures)
            {
                WildCreaturesNoDupes.Add(TamedCreature.ClassName);
            }
            WildCreaturesNoDupes = WildCreaturesNoDupes.Distinct().ToList();
            MainForm MainForm_Control = System.Windows.Forms.Application.OpenForms.OfType<MainForm>().First();
            MainForm_Control.MapInfoDinoSelectionComboBox.Items.Clear();
            foreach (string wildCreature in WildCreaturesNoDupes)
            {
                var aliases = GlobalVariables.DinoAliases.First.First.Where(x => x[1].ToString().Equals(wildCreature) == true).ToArray();
                string DinoName = aliases[0][0].ToString();
                MainForm_Control.MapInfoDinoSelectionComboBox.Items.Add(DinoName);
            }
        }

    }
}
