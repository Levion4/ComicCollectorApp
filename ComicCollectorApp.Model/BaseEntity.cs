using ComicCollectorApp.Model.Comics;
using ComicCollectorApp.Model.Services;
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
    public abstract class BaseEntity : BaseModel
    {
        /// <summary>
        /// Ограничение на количество символов
        /// в имени объекта.
        /// </summary>
        private readonly int _maxLenghtName = 150;

        /// <summary>
        /// Возвращает и задает счетчик всех существующих
        /// объектов данного класса. Задает только во время инициализации.
        /// </summary>
        protected static int AllEntitiesCount { get; private set; }

        /// <summary>
        /// Уникальный идентификатор для всех объектов
        /// данного класса.
        /// </summary>
        protected int _id;

        /// <summary>
        /// Имя.
        /// </summary>
        private string _name;

        /// <summary>
        /// Возвращает и задает коллекцию комиксов,
        /// связанных с данным объектом.
        /// </summary>
        public ICollection<Comic> Comics { get; set; }

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
                    ClearError(nameof(Name));

                    var error = ValueValidator.AssertStringOnLength(
                        _name,
                        _maxLenghtName,
                        nameof(Name));

                    if (error != null)
                    {
                        AddError(nameof(Name), error);
                    }

                    OnPropertyChanged(nameof(HasErrors));
                    OnPropertyChanged(nameof(Name));
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
            Id = ++AllEntitiesCount;
        }
    }
}
