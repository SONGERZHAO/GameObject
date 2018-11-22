# GameObject
roll_a_ball_sez
游戏功能：
      主菜单：  开始游戏  排行榜   退出
      游戏界面： ESC暂停游戏，出现 返回游戏 返回主菜单 退出游戏的选项
      游戏结束界面： 如果打破排行榜记录 会出现输入框 让输入姓名 点击确认按钮返回游戏主菜单
                    如果没有打破记录  出现 You are winer 提示，出现按钮，点击返回主菜单
      排行榜界面：展示排行榜，点击按钮返回主菜单， 排行榜根据吃掉所有小方块花费的的时间排名
Bug：
      button 在分辨率 640*400以上失效(推测时与瞄点有关)

不足： 在场景的切换过程中未加入动画
       排行信息在本地以text明文存储，未采用加密方式

游戏开始界面
    1.Button_Click.cs 
        控制游戏开始场景,同时加载游戏数据
        运用到panel背景，image图片，以及button
        同时调用 GameData.cs,将排行榜信息加载到GameData.cs 中的list上。
    2.GameData.cs
        挂在一个空的GameObject中，在游戏开始页面时将排行信息读入list中并且只读一次
        在场景切换时该GameObject保存下来
        主要数据结构：
                  一个public struct Score  存放玩家姓名与游戏完成时间
                  public  List<Score> list_score 存放排行信息
        主要API 
                  Sort()将list进行排序
                  Write()给list中的数据写入文件中
                  read()将文件中的信息读入到list中
游戏排行榜界面
    1.Charts.cs
        将list中的数据展示到三个Text中，分别为排名，姓名，游戏时间
游戏界面
    1.CameraScript.cs
        控制摄像机与玩家之间的距离，将距离设置为一固定值，防止玩家镜头旋转
    2.Pick_food.cs
        控制小方块的旋转
    3.playerScript.cs
        控制游戏玩家的按键 W A S D Esc
        控制小方块与玩家的碰撞
        控制游戏过程中的 时间 已经吃掉小方块个数
        控制游戏结束时、暂停时的panel的SetActive()
        控制游戏结束时、暂停时的button、InputField
        
