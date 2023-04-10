using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit18.MVP;

namespace Unit18
{
    internal class Presenter
    {
        IView view;
        IModel model;

        /// <summary>
        /// Создаем presenter
        /// </summary>
        /// <param name="View"></param>
        public Presenter(IView View)
        {
            this.view = View;

            model = new Unit18Model();
        }

        /// <summary>
        /// Начало изменений данных в блоке
        /// </summary>
        public void GVCurrentCellChanged()
        {
            model.GVCurrentCellChanged(view.fileRS, view.selectedAnimal);
        }

        /// <summary>
        /// Конец изменений данных в блоке
        /// </summary>
        public void GVCellEditEnding()
        {
            model.GVCellEditEnding();
        }

        /// <summary>
        /// Добавление данных
        /// </summary>
        public void MenuItemAddClick()
        {
            var animals = model.MenuItemAddClick(view.fileRS);
            view.animals = animals;
        }

        /// <summary>
        /// Удаление данных
        /// </summary>
        public void MenuItemDeleteClick()
        {
            var aniamls = model.MenuItemDeleteClick(view.fileRS, view.selectedAnimal);
            view.animals = aniamls;
        }

        /// <summary>
        /// Изменение мода сохранения 
        /// </summary>
        public void SelectionChanged()
        {
            var aniamls = model.SelectionChanged(view.fileRS);
            view.animals = aniamls;
        }

        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public void GetStart()
        {
            var mode = model.GetStart();
            view.fileRSMode = mode;
        }
    }
}
