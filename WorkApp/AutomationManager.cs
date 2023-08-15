namespace WorkApp
{
    internal class AutomationManager
    {
        private readonly string[] values;
        private readonly string template;
        public AutomationManager(string[] values, string template)
        {
            this.values = values;
            this.template = template;
        }

        public string StartAutomate()
        {
            RepList repList = new RepList();
            RemainingReplacements remainingReplatements = new RemainingReplacements();
            RepSelections repSelections = new RepSelections();

            string modifiedTemplate = repList.Replace(template, values);
            string modifiedTemplateStage2 = repSelections.Replace(modifiedTemplate, values);
            string result = remainingReplatements.ReadValues(values, modifiedTemplateStage2);

            return result;
        }

    }
}