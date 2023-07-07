namespace BussinesObject.API.Models.AccountsData
{
    public class ObjectDescribe
    {
        public bool activateable { get; set; }
        public object associateEntityType { get; set; }
        public object associateParentEntity { get; set; }
        public bool createable { get; set; }
        public bool custom { get; set; }
        public bool customSetting { get; set; }
        public bool deepCloneable { get; set; }
        public bool deletable { get; set; }
        public bool deprecatedAndHidden { get; set; }
        public bool feedEnabled { get; set; }
        public bool hasSubtypes { get; set; }
        public bool isInterface { get; set; }
        public bool isSubtype { get; set; }
        public string keyPrefix { get; set; }
        public string label { get; set; }
        public string labelPlural { get; set; }
        public bool layoutable { get; set; }
        public bool mergeable { get; set; }
        public bool mruEnabled { get; set; }
        public string name { get; set; }
        public bool queryable { get; set; }
        public bool replicateable { get; set; }
        public bool retrieveable { get; set; }
        public bool searchable { get; set; }
        public bool triggerable { get; set; }
        public bool undeletable { get; set; }
        public bool updateable { get; set; }
        public Urls urls { get; set; }
    }
}
