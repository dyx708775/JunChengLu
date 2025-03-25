using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 宫女:NPC
{
    public int 职务 = 0;
    public string 主子啊 = "";
    public int 主子 = -1;
    public int 经验啊 = 0;
    public int 入宫时长 = 1;
    public void 打入慎刑司程序()
    {
        if (职务 == 1 || 职务 == 0)
        {

        }
        else if(职务==21)
        {
            if (主子 != -1)
            {
                
            }
        }
        if (性别 == "女") 职务 = 7;
        else 职务 = 11;
        状态 = 1;
        主子 = -1;
    }
}
