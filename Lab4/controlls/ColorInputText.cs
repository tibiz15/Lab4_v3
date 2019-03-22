
namespace Lab4.controlls
{
    class ColorInputText : ColorControll
    {
        
        protected override bool ValidText(string text)
        {
            return (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text));
                
        }
    }
}
