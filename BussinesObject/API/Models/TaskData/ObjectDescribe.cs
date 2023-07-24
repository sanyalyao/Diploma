namespace BussinesObject.API.Models.TaskData
{
    public class ObjectDescribe
    {
        public bool Activateable { get; set; }
        public object AssociateEntityType { get; set; }
        public object AssociateParentEntity { get; set; }
        public bool Createable { get; set; }
        public bool Custom { get; set; }
        public bool CustomSetting { get; set; }
        public bool DeepCloneable { get; set; }
        public bool Deletable { get; set; }
        public bool DeprecatedAndHidden { get; set; }
        public bool FeedEnabled { get; set; }
        public bool HasSubtypes { get; set; }
        public bool IsInterface { get; set; }
        public bool IsSubtype { get; set; }
        public string KeyPrefix { get; set; }
        public string Label { get; set; }
        public string LabelPlural { get; set; }
        public bool Layoutable { get; set; }
        public bool Mergeable { get; set; }
        public bool MruEnabled { get; set; }
        public string Name { get; set; }
        public bool Queryable { get; set; }
        public bool Replicateable { get; set; }
        public bool Retrieveable { get; set; }
        public bool Searchable { get; set; }
        public bool Triggerable { get; set; }
        public bool Undeletable { get; set; }
        public bool Updateable { get; set; }
        public Urls Urls { get; set; }
    }
}
