namespace SearchAlgorithms
{
    /// <summary>
    /// Idea is to divide each step on two parts to speed up the sorting process
    /// same for seaching. 
    /// Data must be sorted before searching. Binary search only works for sorted data.
    /// Algorithm takes element in the middle and compares against the search value.
    /// If equal then it's done.
    /// If element is greater than search value (element > value) then search the left half
    /// If element is smaller than search value (element < value) then search the right half
    /// log(n) steps
    /// </summary>
    public class BinarySearch
    {
    }
}
