package baekjoon.implementation;

// 백준 - 기차가 어둠을 헤치고 15787
// https://www.acmicpc.net/problem/15787

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.StringTokenizer;

public class train_15787 {

    public static int N, M;
    public static ArrayList<boolean[]> trainList = new ArrayList<>();

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());

        N = Integer.parseInt(st.nextToken());
        M = Integer.parseInt(st.nextToken());

        for (int i = 0; i < N; i++) trainList.add(new boolean[20]);

        for (int i = 0; i < M; i++) {
            st = new StringTokenizer(br.readLine());
            int num = Integer.parseInt(st.nextToken());
            if (num == 1 || num == 2) {
                int trainNum = Integer.parseInt(st.nextToken());
                int seatNum = Integer.parseInt(st.nextToken());
                trainList.get(trainNum-1)[seatNum-1] = (num == 1) ? true : false;
                System.out.println(trainList.get({trainNum - 1})[seatNum-1]);
            } else {
                int trainNum = Integer.parseInt(st.nextToken()) - 1;
                if (num == 3) goBack(trainNum);
                else goFront(trainNum);
            }
        }

        for (boolean[] list : trainList) {
            String cur = "";
            for (int i = 0; i < list.length; i++) {
                if (list[i]) cur += "O";
                else cur += "X";
            }
            System.out.println(cur);
        }

        int result = 0;
        ArrayList<String> trainCheckList = new ArrayList<>();
        for (boolean[] list : trainList) {
            String cur = "";
            for (int i = 0; i < list.length; i++) {
                if (list[i]) cur += "O";
                else cur += "X";
            }
            System.out.println(cur);
            if (!trainCheckList.contains(cur)) {
                result++;
                trainCheckList.add(cur);
            }
        }

        System.out.println(result);
    }

    public static void goFront(int trainNum) {

        // 20번째 자리에 앉은 사람 하차
        if (trainList.get(trainNum)[19]) trainList.get(trainNum)[19] = false;

        for (int i = 18; i > 0; i--) {
            trainList.get(trainNum)[i] = trainList.get(trainNum)[i-1];
        }

        trainList.get(trainNum)[0] = false;
    }

    public static void goBack(int trainNum) {

        for (int i = 0; i < 19; i++) {
            trainList.get(trainNum)[i] = trainList.get(trainNum)[i+1];
        }

        trainList.get(trainNum)[19] = false;
    }
}
