package baekjoon.implementation;

// 백준 - 스위치 1244
// https://www.acmicpc.net/problem/1244

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class switch_1244 {

    public static int N;
    public static int[] switch_state;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        N = Integer.parseInt(br.readLine());
        switch_state = new int[N+1];
        StringTokenizer st = new StringTokenizer(br.readLine());
        for (int i = 1; i <= N; i++) switch_state[i] = Integer.parseInt(st.nextToken());

        int student = Integer.parseInt(br.readLine());
        for (int i = 0; i < student; i++) {
            st = new StringTokenizer(br.readLine());
            int gender = Integer.parseInt(st.nextToken());
            int switchNum = Integer.parseInt(st.nextToken());

            if (gender == 1) changeSwitchByBoy(switchNum);
            else changeSwitchByGirl(switchNum);
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 1; i <= N; i++) {
            sb.append(switch_state[i]).append(" ");
            if (i % 20 == 0) sb.append("\n");
        }
        System.out.println(sb);
    }

    // 남학생이 스위치를 조작하는 경우
    // num의 배수이면 상태를 바꿈
    public static void changeSwitchByBoy(int num) {
        for (int i = 1; i <= N; i++) {
            if (i % num == 0) switch_state[i] = Math.abs(switch_state[i] - 1);
        }
    }

    // 여학생이 스위치를 조작하는 경우
    // num을 기준으로 좌우 대칭이면 상태를 바꿈
    public static void changeSwitchByGirl(int num) {
        switch_state[num] = Math.abs(switch_state[num] - 1);

        for (int i = 1; (num-i >= 1) && (num+i <= N); i++) {
            if (switch_state[num-i] == switch_state[num+i]) {
                switch_state[num-i] = Math.abs(switch_state[num-i] - 1);
                switch_state[num+i] = Math.abs(switch_state[num+i] - 1);
            } else break;
        }
    }
}
