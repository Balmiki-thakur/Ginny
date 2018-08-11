using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
  public  class RuleEnginDo
    {
      public int Eid { get; set; }
      public string RuleName { get; set; }
      public string ErrorMessage { get; set; }
      public int FormName { get; set; }
      public int ConditionFormName { get; set; }
      public int FieldName { get; set; }
      public int CompairFieldName { get; set; }
      public string Conditon { get; set; }
      public string Equelfield { get; set; }
      public string CatgorieCondition { get; set; }
      public string PriceConditionrule { get; set; }
      public string Fieldvalue { get; set; }
      public string Condition { get; set; }
      public string Clientcondition { get; set; }
      public string MainConditon { get; set; }
      public int ConditionField { get; set; }
    }
  public class RuleEnginDoList : List<RuleEnginDo>
  {
      public RuleEnginDoList() { }
  }
}
