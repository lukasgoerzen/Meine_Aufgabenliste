using Meine_Aufgabenliste.Models;

namespace Meine_Aufgabenliste.Controllers.Services {
    public interface IToDoService {
        List<ToDo> LoadToDos();
        void SaveToDos(List<ToDo> toDos);
        List<ToDo> SearchToDos(List<ToDo> toDos, string suchbegriff);
    }
}
