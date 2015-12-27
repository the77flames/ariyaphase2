namespace ProjectConakry.DomainObjects {
    /// <summary>
    /// Exposes the basic support for competitive entities.
    /// </summary>
public interface IVoteable
    {
        /// <summary>
        /// This corressponds to the total eligible votes ascribed to an entity.
        /// </summary>
        int TotalVotes {get; set;}
    }
}
