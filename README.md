Задача 6. Рассмотрим одномерную двухфазную задачу Стефана. Имеется
одномерная теплопроводящая среда, находящаяся в жидком и твердом состояниях. В
начальный момент ее температура меньше температуры плавления Tпл. В точках с
координатами x меньше 2 имеются источники тепла, под воздействием которых
происходит плавление на границе раздела фаз, протекающее при температуре Tпл.
Необходимо найти распределение температуры в последовательные моменты времени
и определить расположение границы фаз.
Компьютерные модели распространения тепла в средах с изменяющимся фазовым
состоянием представляют особый интерес. Среди них задача о промерзании грунта
(решена Стефаном 1889 г.), задача о кристаллизации расплава при погружении в него
пластины, задача о нарастании ледяного покрова, металлургическая задача об
остывании расплавленных тел и образовании слитка, задача об отвердевании земного
шара из расплавленного состояния и другие.
Задача сводится к решению уравнения теплопроводности совместно с условием
Стефана, вытекающего из уравнения теплового баланса:
где λ –– удельная теплота плавления, ρ – плотность среды, x=ξ(t) – уравнение
границы разделяющей жидкую и твердую фазы, k1, k2 – коэффициенты
температуропроводности жидкой и твердой фазы соответственно, T1 и T2 –
температуры вблизи границы раздела x=ξ(t) со стороны жидкой и твердой фаз.
Рассмотрим решение задачи Стефана для одномерной среды длиной L, когда
температура левого конца все время выше Tпл, правый конец теплоизолирован, а
граница раздела фаз смещается вправо (рис. 7). На каждом шаге определяется число
узлов j, для которых Ti больше Tпл (i не превосходит j). Температура в j–том узле
незначительно отличается от температуры плавления Tпл, поэтому переменной Tj
присваивается значение Tпл. Количество теплоты, приходящее в j-тый узел, на шаге t
Здесь kj-1 и kj+1 – коэффициенты температуропроводности слева и справа от
границы раздела двух фаз.
Рис. 7. Одномерная двухфазная задача Стефана.
Если количество теплоты dqt, поступающее в j-тый слой, меньше заданного
значения теплоты плавления qпл=λρΔx, которую необходимо затратить, чтобы
расплавить слой толщиной h=Δx единичной площади, то фронт плавления не
смещается. Программа вычисляет температуру в 2, 3, ..., (j-1)-том, а затем в (j+1), (j+2),
..., (N-1)-ом узлах. Температура Tj остается равной Tпл; значение dqt накапливается в
переменной dq. Если dqt превышает qпл, то j–тый слой плавится, и граница раздела
жидкой и твердой фаз смещается вправо на 1 узел. Величина dqt уменьшается на
затраченную энергию qпл. Переменной Tj+1 присваивается значение Tпл, и все
повторяется снова.
