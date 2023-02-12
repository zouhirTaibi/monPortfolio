using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{

    //T c'est de type classe
    //c'est une classe generique pour qu'on l'utilise avec plusieurs type de classe
    public interface IGenericRepository<T> where T:class
    {
        //recuperer tt les valeurs de meme type T
        IEnumerable<T> GetAll();
        //recuperer une seule valeur de type T
        T GetById(object id);
        //inserer une valeur de type T
        void Insert(T entity);
        //Modifier une valeur de type T
        void Update(T entity);
        //Supprimer une valeur de type T
        void Delete(object id);
    }

}
