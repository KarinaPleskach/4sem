
namespace PlugIn
{
    public interface IPlugin
    {
        string PluginName { get; } // имя плагина
        string DisplayPluginName { get; } // имя плагина, которое отображается
        string PluginDescription { get; } // описание плагина
        string Author { get; } // имя автора
        int Version { get; } // версия
        IPluginHost Host { get; set; } // ссылка на главную форму

        void Show(); // отображает форму
    }

    public interface IPluginHost
    {
        bool Register( IPlugin plug );
    }
}