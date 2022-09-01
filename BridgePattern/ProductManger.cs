using System;

namespace BridgePattern
{
    /// <summary>
    /// ��Ʒ����
    /// </summary>
    public class ProductManger : Manager
    {
        public ProductManger(Project currentProject) : base(currentProject)
        {
        }
        public override void SchedulePlan()
        {
            base.CurrentProject.MakePlan();
        }

        public override void AssignTasks()
        {
            base.CurrentProject.ScheduleTask();
        }

        public override void ControlProcess()
        {
            base.CurrentProject.ControlProcess();
        }
        public void AnalyseRequirement()
        {
            base.CurrentProject.AnalyzeRequirement();
        }

        public void DesignProduct()
        {
            base.CurrentProject.DesignProduct();
        }
        
        public override void ManageProject()
        {
            Console.WriteLine($"��Ʒ������{base.CurrentProject.ProjectName}����");
            AnalyseRequirement();
            DesignProduct();
            base.ManageProject();
        }
    }
}