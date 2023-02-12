namespace Core.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        //pour utiliser seulement le IGenericRepository
        //pour recuprer les valeurs
        IGenericRepository<T> Entity { get; }
        //pour sauvegarder
        void Save();
    }
}
