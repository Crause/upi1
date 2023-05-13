# Лабораторная работа №1
## ББМО-02-22 Кузьмин Владимир Дмитриевич

Данное приложение состоит из двух основных функций:
1. Вывод уникальных пересечений элементов между двумя одномерными массивами, введёнными пользователем;
2. Вывод в табличном представлении списка студентов, у которых в зачётной книжке присутствуют экзамены с датой выше, чем введёная пользователем.

Приложение начинает работу с бесконечного цикла, в котором предлагает пользователю выбрать дальнейшую функцию. Для выхода из цикла нужно ввести символ ~ (тильда).
В процессе взаимодействия с приложением в консоль будут выводиться необходимые подсказки.

Для успешной работы функции номер 2 необходим файл students.json. Структура файла представлена в репозитории, а содержимое файла представлено в примерах ниже.

Пример использования функции номер 1:
```
Введите номер задания [1 или 2]:
#Выход -> '~'
1
Введите элементы массива 1 через пробел:
1 2 3  4 12 11 25151  zfskasf kaf ks ss ssss s
Введите элементы массива 2 через пробел:
5 21 z a s kaf 2 11
Общие элементы: 2, 11, kaf, s
Задание завершено.
```

Пример использования функции номер 2:
```
Введите номер задания [1 или 2]:
#Выход -> '~'
2
Введите нижнюю границу даты экзамена в формате "2000-01-01":
2021-01-01
----------------------------------------------------------------
|           FirstName|          SecondName|            LastName|
----------------------------------------------------------------
|            Vladimir|              Kuzmin|         Dmitrievich|
|               Pavel|               Ivlev|           Igorevich|
|          Konstantin|           Abronskiy|         Vitalievich|
----------------------------------------------------------------
Задание завершено.
```

Пример файла students.json:
```
{
    "Studs":[
        {
            "Birthday":"2000-06-09T00:00:00",
            "Recs":
            [
                {"Subject":"Math",
                "Date":"2022-01-01T00:00:00",
                "Mark":"5",
                "Teacher":{"FirstName":"Leonid","SecondName":"Konobeev","LastName":"Sergeevich"}
                },
                {"Subject":"Russian",
                "Date":"2022-02-01T00:00:00",
                "Mark":"4",
                "Teacher":{"FirstName":"Maria","SecondName":"Petrova","LastName":"Anatolievna"}
                }
            ],
            "FirstName":"Vladimir",
            "SecondName":"Kuzmin",
            "LastName":"Dmitrievich"
        },
        {
            "Birthday":"2001-03-19T00:00:00",
            "Recs":
            [
                {"Subject":"Math",
                "Date":"2023-06-01T00:00:00",
                "Mark":"3",
                "Teacher":{"FirstName":"Leonid","SecondName":"Konobeev","LastName":"Sergeevich"}
                },
                {"Subject":"Russian",
                "Date":"2023-06-21T00:00:00",
                "Mark":"passed",
                "Teacher":{"FirstName":"Maria","SecondName":"Petrova","LastName":"Anatolievna"}
                }
            ],
            "FirstName":"Pavel",
            "SecondName":"Ivlev",
            "LastName":"Igorevich"
        },
        {
            "Birthday":"1999-02-11T00:00:00",
            "Recs":
            [
                {"Subject":"Math",
                "Date":"2021-01-05T00:00:00",
                "Mark":"4",
                "Teacher":{"FirstName":"Leonid","SecondName":"Konobeev","LastName":"Sergeevich"}
                },
                {"Subject":"English",
                "Date":"2021-01-09T00:00:00",
                "Mark":"passed",
                "Teacher":{"FirstName":"Oksava","SecondName":"Galich","LastName":"Magomedovna"}
                }
            ],
            "FirstName":"Konstantin",
            "SecondName":"Abronskiy",
            "LastName":"Vitalievich"
        }
    ]
}
```
