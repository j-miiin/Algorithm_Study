
// 백준 - 스택 10828
// https://www.acmicpc.net/problem/10828

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Stack;
import java.util.StringTokenizer;

public class stack_10828 {

    public static Stack<Integer> stack = new Stack<>();

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < N; i++) {
            StringTokenizer st = new StringTokenizer(br.readLine());
            String command = st.nextToken();

            if (command.equals("push")) {
                stack.push(Integer.parseInt(st.nextToken()));
            } else if (command.equals("pop")) {
                sb.append((stack.size() >= 1) ? stack.pop() : -1).append("\n");
            } else if (command.equals("size")) {
                sb.append(stack.size()).append("\n");
            } else if (command.equals("empty")) {
                sb.append((stack.size() != 0) ? 0 : 1).append("\n");
            } else if (command.equals("top")) {
                sb.append((stack.size() >= 1) ? stack.peek() : -1).append("\n");
            }
        }

        System.out.println(sb);
    }
}
