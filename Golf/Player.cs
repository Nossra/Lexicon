
namespace Golf
{
    class Player
    {
        private string _name;
        private int _input;

        public Player(string name)
        {
            this._name = name;
        }
       
        public string Name { get => _name; set => _name = value; }
    }
}
