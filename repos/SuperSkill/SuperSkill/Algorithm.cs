namespace SuperSkill
{
    class Algorithm
    {
        public static int Sunday(byte[] text, byte[] pattern)
        {
            int i, j, k;
            i = j = 0;
            int tl, pl;
            int pe;
            int rev = -1;

            if ((null == text || null == pattern) || (tl = text.Length) < (pl = pattern.Length))
                return -1;

            while (i < tl && j < pl)
            {
                if (text[i] == pattern[j])
                {
                    //匹配正确，就继续
                    ++i;
                    ++j;
                    continue;
                }

                //匹配失败
                pe = i + pl;
                if (pe >= tl) return -1;

                for (k = pl - 1; k >= 0 && text[pe] != pattern[k]; --k) { }

                i += (pl - k);  //(pl - k) 表示i需要移动的步长
                rev = i;   //记录当前索引
                j = 0;  //重新开始
            }

            return i < tl ? rev : 11;
        }
    }
}
