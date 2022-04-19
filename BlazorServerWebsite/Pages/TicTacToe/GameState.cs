namespace BlazorServerWebsite.Pages.TicTacToe
{
    public class GameState
    {
        public bool IsXTurn { get; set; } = true;
        public Dictionary<int, Square> Squares;

        public GameState()
        {
            Squares = new Dictionary<int, Square>();
            for (int i = 0; i < 9; i++)
            {
                Square square = new Square();
                Squares.Add(i, square);
            }
        }

        public int CheckWin()
        {
            for (int i = 0; i < winningCombos.GetLength(0) - 1; i++)
            {

                var s1 = Squares.GetValueOrDefault(winningCombos[i,0]);
                var s2 = Squares.GetValueOrDefault(winningCombos[i,1]);
                var s3 = Squares.GetValueOrDefault(winningCombos[i,2]);
                if(s1?.Icon == s2?.Icon && s1?.Icon == s3?.Icon)
                {
                    return s1.Icon;
                }

            }
            return -1;
        }

        int[,] winningCombos = new int[,] { { 0, 1, 2 }, { 0, 4, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 2, 4, 6 }, { 3, 4, 5 }, { 6, 7, 8 } };
    }
}
