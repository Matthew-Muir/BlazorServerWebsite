namespace BlazorServerWebsite.Pages.TicTacToe
{
    public class Square
    {
        public int Position { get; set; }
        public string[] Classes { get; set; } = default!;
        public string IconClass
        {
            get
            {
                switch (Icon)
                {
                    case 0:
                        return "oi oi-target";
                    case 1:
                        return "oi oi-x";
                    default:
                        return "";

                }
            }
            set { }
        }
        public int Icon { get; set; } = -1;

        public string StylesToString()
        {
            return String.Join(' ', Classes);
        }
    }
}
