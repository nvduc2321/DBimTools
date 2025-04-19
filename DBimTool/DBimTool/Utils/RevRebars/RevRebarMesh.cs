namespace DBimTool.Utils.RevRebars
{
    public partial class RevRebarMesh : ObservableObject
    {
        [ObservableProperty]
        private string _nameDiameter;
        private double _spacingMm;
        public double SpacingMm
        {
            get => _spacingMm;
            set
            {
                _spacingMm = value;
                OnPropertyChanged();
                SpacingMmChanged?.Invoke();
            }
        }
        public Action SpacingMmChanged {  get; set; }
        public List<RevRebar> RevRebars { get; set; }
    }
}
