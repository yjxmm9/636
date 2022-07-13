# 636

实现参考：https://blog.51cto.com/u_15296123/3370868

# 关卡系统

## 第一关：杭州

风格：古代
![Image text](https://github.com/yjxmm9/636/raw/main/Reference Pic/image-20220621213223391.png)


标志：六和塔、桥


![Image text](https://github.com/yjxmm9/636/raw/main/Reference%20Pic/image-20220621213140749.png)

![Image text](https://github.com/yjxmm9/636/raw/main/Reference%20Pic/image-20220621213254346.png)

![Image text](https://github.com/yjxmm9/636/raw/main/Reference%20Pic/image-20220621213127421.png)




船：古风龙舟







## 第二关：台儿庄

风格：抗日红色

标志：战壕，炮台，瞭望塔，铁路桥，雕像

![Image text](https://github.com/yjxmm9/636/raw/main/Reference%20Pic/image-20220621213317341.png)



![Image text](https://github.com/yjxmm9/636/raw/main/Reference%20Pic/image-20220621213326515.png)



船：战船





## 第三关：北京

风格：现代

标志：大裤衩，现代建筑，鸟巢，水立方等

![Image text](https://github.com/yjxmm9/636/raw/main/Reference%20Pic/image-20220621214431663.png)

船：快艇



# 运动系统

左右移动：可以自由左右移动

上下移动：跳，蹲

运动系统实现参考：https://www.bilibili.com/video/BV1A4411L77W?spm_id_from=333.337.search-card.all.click&vd_source=e094efdd3063cf10d20b43f659f855a6





# 障碍系统

左右躲避：石头，漩涡，水草，横木，码头

跳：风筝，炮弹，无人机，桥的两侧

蹲：桥的中间，岸旁伸出的树枝



## 需要的道具模型(障碍)

第一关:

石头,古代桥,树

第二关:

横木,石头,通火车的桥,炮弹,岸边伸出的炮台

第三关:

石头,漩涡,无人机,现代桥,岸边的船,水草(浮在水面上),其他运输船,路边钓鱼人

# 道具系统

加速

磁铁效果的实现：http://www.4k8k.xyz/article/yy763496668/76944915

护盾



# 问答系统

第一次失败后可以通过答题复活



# 收集系统

每关有三个收集品，收集一个即可解锁一个本关的知识,收集到三个即三星通关





# UI

### 主界面

![image-20220713140143255](https://jupiter-typora-pic.oss-cn-shanghai.aliyuncs.com/image-20220713140143255.png)

需要的美术资源:

​	背景(16:9)

​	按键边框(通用)

​	标题(和背景画一起)



### 关卡选择

![image-20220713140542857](https://jupiter-typora-pic.oss-cn-shanghai.aliyuncs.com/image-20220713140542857.png)

需要的美术资源:

​	圆形按键(用于选择关卡)

​	背景

​	返回按钮



### 游戏界面和暂停界面

![image-20220713141638282](https://jupiter-typora-pic.oss-cn-shanghai.aliyuncs.com/image-20220713141638282.png)

需要的美术资源:

​	暂停界面边框

​	按钮边框(通用)



### 死亡界面

![image-20220713141956610](https://jupiter-typora-pic.oss-cn-shanghai.aliyuncs.com/image-20220713141956610.png)

需要的美术资源:

​	与之前的可以共用





问题:

需不需要一关一关解锁(涉及到要不要做锁的美术资源以及如何实现)

需不需要每关有星星(涉及到星星的美术资源以及如何实现)
