using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigef.Poc.FTCapp.Util.DTO
{
    public class ElementoScrap
    {
        public string OnClick{get;set;}
        
        public string TagName{get;set;}

        public string TabIndex { get; set; }
        
        public bool Selected{get;set;}
       
        public bool Enable{get;set;}
       
        public bool Displayed{get;set;}
       
        public string Text{get;set;}
        
        public string Type{get;set;}
        
        public string Height{get;set;}
       
        public string Width{get;set;}
       
        public int X{get;set;}
        
        public int Y{get;set;}
        
        public string UICodigo{get;set;}
        
        public string Label{get;set;}
       
        public bool IsGrid{get;set;}
      
        public bool IsComposto{get;set;}
       
        public bool IsCampoPesquisa{get;set;}
        
        public string ClassName{get;set;}

        public bool Grid { get; set; }

        public bool CampoPesquisa { get; set; }
    }
}
