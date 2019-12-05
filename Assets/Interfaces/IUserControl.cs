//1.Интерфейс управления. 
//Унаследуется от интерфейса, который наделяет ему свойство Object. 
public interface IUserControl: IUnityComponent  
{
   float X { get; }
   float Y { get; }
}
