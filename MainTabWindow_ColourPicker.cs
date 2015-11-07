using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using UnityEngine;

namespace ColourPicker
{
    class MainTabWindow_ColourPicker : MainTabWindow
    {
        public ColourWrapper    BGCol;
        public Texture2D        BGTex;

        public MainTabWindow_ColourPicker()
        {
            BGCol = new ColourWrapper(Color.grey);
            BGTex = SolidColorMaterials.NewSolidColorTexture( BGCol.Color );
        }
        
        public override void DoWindowContents( Rect inRect )
        {
            GUI.DrawTexture( inRect, BGTex );
            Rect button = new Rect(0f, 0f, 200f, 35f);
            button = button.CenteredOnXIn( inRect ).CenteredOnXIn( inRect );

            if (Widgets.TextButton(button, "Change Colour" ) )
            {
                Find.WindowStack.Add( new Dialog_ColourPicker( BGCol, delegate { BGTex = SolidColorMaterials.NewSolidColorTexture( BGCol.Color ); } ) );
            }
        }
    }
}
