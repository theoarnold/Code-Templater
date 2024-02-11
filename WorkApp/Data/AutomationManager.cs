namespace WorkApp.Data
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

        internal string StartAutomate()
        {
            ModifyTemplate modifyTemplate = new ModifyTemplate();

            string modifiedTemplate = modifyTemplate.RepList(template, values);
            string modifiedTemplateStage2 = modifyTemplate.RepSelections(modifiedTemplate, values);
            string result = modifyTemplate.RemainingReplacements(values, modifiedTemplateStage2);

            return result;
        }

    }
}