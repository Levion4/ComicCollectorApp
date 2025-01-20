using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicCollectorApp.Model
{
    /// <summary>
    /// Базовый класс для сущностей с идентификатором и именем.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Счетчик всех существующих объектов данного класса.
        /// </summary>
        private static int _allEntitiesCount;

        /// <summary>
        /// Уникальный идентификатор для всех объектов
        /// данного класса.
        /// </summary>
        private int _id;

        /// <summary>
        /// Имя.
        /// </summary>
        private string _name;

        /// <summary>
        /// Возвращает и задает уникальный идентификатор
        /// комикса. Задает только во время инициализации.
        /// </summary>
        public int Id
        {
            get 
            { 
                return _id; 
            }
            private set
            { 
                _id = value; 
            }
        }

        /// <summary>
        /// Возвращает и задает имя.
        /// </summary>
        public string Name
        {
            get 
            { 
                return _name; 
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="BaseEntity"/>.
        /// </summary>
        /// <param name="name">Имя.</param>
        protected BaseEntity(string name)
        {
            Name = name;
            Id = _allEntitiesCount++;
        }
    }
}
