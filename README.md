# UnityBindingDemo

NData - плагин для NGUI, реализующий возможность биндинга между данными в коде и элементами пользовательского интерфейса.
Целью являлось написание аналога, который будет работать на Unity UI.

В репозитории представлено как само решение (Assets/BndSystem), так и сцена демонстрирующая возможности биндингов.

Главный недостаток Ndata - ожидание следующего кадра (особенно было заметно когда изменялся visible у крупного объекта, и возникало моргание на один кадр) в данном решении отсутствует.