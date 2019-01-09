using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArkSavegameToolkitNet.Domain;

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

                //assign the new data to the domain model
                GameData.ApplyPreviousUpdate();

                //query the domain model
                
            }
            return GameData.WildCreatures;
        }

        public async Task DisplayInfo(string DinoClass)
        {
            MainForm MainForm_Control = System.Windows.Forms.Application.OpenForms.OfType<MainForm>().First();
            MainForm_Control.MapInfoDinoListDataGridView.Rows.Clear();
            // Variable GameData can be called again, since it it already defined when the server data is loaded
            var calledDinos = GameData.WildCreatures.Where(x => x.ClassName?.Equals(DinoClass) == true).ToArray();
            foreach (ArkWildCreature dino in calledDinos)
            {
                string[] DinoInfoRow = { dino.Gender.ToString() , dino.BaseLevel.ToString(), dino.Location.Latitude.ToString(), dino.Location.Longitude.ToString(), dino.IsTameable.ToString() };
                MainForm_Control.MapInfoDinoListDataGridView.Rows.Add(DinoInfoRow);
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
                MainForm_Control.MapInfoDinoSelectionComboBox.Items.Add(wildCreature);
            }
        }

    }
}
