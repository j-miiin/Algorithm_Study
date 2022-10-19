
// 백준 - ZOAC 3 20436
// https://www.acmicpc.net/problem/20436

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.StringTokenizer;

public class zoac3_20436 {

    public static String[][] keyboard = {{"q", "w", "e", "r", "t", "y", "u", "i", "o", "p"},
                                        {"a", "s", "d", "f", "g", "h", "j", "k", "l"},
                                        {"z", "x", "c", "v", "b", "n", "m"}};

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        String leftStart = st.nextToken();
        String rightStart = st.nextToken();
        String target = br.readLine();

        int[] left = findPos(leftStart);
        int lx = left[0];
        int ly = left[1];

        int[] right = findPos(rightStart);
        int rx = right[0];
        int ry = right[1];

        String[] l = {"q", "w", "e", "r", "t", "a", "s", "d", "f", "g", "z", "x", "c", "v"};
        String[] r = {"y", "u", "i", "o", "p", "h", "j", "k", "l", "b", "n", "m"};

        ArrayList<String> leftArr = new ArrayList<>(Arrays.asList(l));
        ArrayList<String> rightArr = new ArrayList<>(Arrays.asList(r));

        int time = 0;
        for (int i = 0; i < target.length(); i++) {
            String cur = target.charAt(i) + "";

            if (leftArr.contains(cur)) {
                int[] next = findPos(cur);
                int nextX = next[0];
                int nextY = next[1];

                time += Math.abs(lx-nextX) + Math.abs(ly-nextY);
                time++;
                lx = nextX;
                ly = nextY;
            } else if (rightArr.contains(cur)) {
                int[] next = findPos(cur);
                int nextX = next[0];
                int nextY = next[1];

                time += Math.abs(rx-nextX) + Math.abs(ry-nextY);
                time++;
                rx = nextX;
                ry = nextY;
            }
        }
        System.out.println(time);
    }

    public static int[] findPos(String s) {
        for (int i = 0; i < keyboard.length; i++) {
            for (int j = 0; j < keyboard[i].length; j++) {
                if (s.equals(keyboard[i][j])) return new int[]{i, j};
            }
        }
        return new int[]{0, 0};
    }
}
