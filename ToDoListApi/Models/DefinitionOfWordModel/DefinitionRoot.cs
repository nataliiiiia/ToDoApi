namespace ToDoListApi.Models.DefinitionOfWordModel
{
    public class DefinitionRoot
    {
        public List<Entry> entries { get; set; }
    }
    public class Lexeme
    {
        public List<Sense> senses { get; set; }
    }
    public class Entry
    {
        public string entry { get; set; }
        public List<Lexeme> lexemes { get; set; }
    }
    public class Sense
    {
        public string definition { get; set; }
    }
}
