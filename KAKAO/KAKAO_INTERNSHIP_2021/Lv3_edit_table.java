package kakao_internship_2021;

// 2021 카카오 채용연계형 인턴십 - 표 편집
// https://school.programmers.co.kr/learn/courses/30/lessons/81303

import java.util.*;

class Node {
    int up;
    int down;

    Node(int up, int down) {
        this.up = up;
        this.down = down;
    }
}

public class Lv3_edit_table {

    public static Node[] table;
    public static Stack<Integer> stack = new Stack<>();
    public static StringBuilder sb;

    public static void main(String[] args) {

        int n = 8;
        int k = 2;
        String[] cmd = {"D 2","C","U 3","C","D 4","C","U 2","Z","Z","U 1","C"};

        System.out.println(solution(n, k, cmd));
    }

    public static String solution(int n, int k, String[] cmd) {
        sb = new StringBuilder("O".repeat(n));

        table = new Node[n+1];
        for (int i = 0; i < n; i++) {
            table[i] = new Node(i-1, i+1);
        }

        table[0].up = -1;
        table[n-1].down = -1;

        int curIdx = k;
        for (int i = 0; i < cmd.length; i++) {
            String command = "";
            int count = 0;
            if (cmd[i].length() > 1) {
                StringTokenizer st = new StringTokenizer(cmd[i]);
                command = st.nextToken();
                count = Integer.parseInt(st.nextToken());
            } else {
                command = cmd[i];
            }

            // D
            if (command.equals("D")) {
                for (int j = 0; j < count; j++) curIdx = table[curIdx].down;
            }

            // U
            else if (command.equals("U")) {
                for (int j = 0; j < count; j++) curIdx = table[curIdx].up;
            }

            // C
            else if (command.equals("C")) {
                curIdx = delete(curIdx);
            }

            // Z
            else if (command.equals("Z")) {
                restore();
            }
        }

        String answer = sb.toString();
        return answer;
    }

    public static int delete(int curIdx) {
        int curUp = table[curIdx].up;
        int curDown = table[curIdx].down;

        if (curUp != -1) table[curUp].down = curDown;
        if (curDown != -1) table[curDown].up = curUp;

        stack.push(curIdx);
        sb.setCharAt(curIdx, 'X');

        if (curDown != -1) return curDown;
        else return curUp;
    }

    public static void restore() {
        int curIdx = stack.pop();
        sb.setCharAt(curIdx, 'O');

        int curUp = table[curIdx].up;
        int curDown = table[curIdx].down;

        if (curUp != -1) table[curUp].down = curIdx;
        if (curDown != -1) table[curDown].up = curIdx;
    }
}
