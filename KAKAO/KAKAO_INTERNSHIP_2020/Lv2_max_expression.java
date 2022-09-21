package kakao_internship_2020;

// 2020 카카오 인턴십 - Lv2 수식 최대화
// https://school.programmers.co.kr/learn/courses/30/lessons/67257

import java.util.ArrayList;

public class Lv2_max_expression {
    public static void main(String[] args) {
        String expression = "50*6-3*2";

        System.out.println(solution(expression));
    }

    public static long solution(String expression) {

        ArrayList<Long> num = new ArrayList<>();
        ArrayList<Character> op = new ArrayList<>();
        String tmp = "";
        for (int i = 0; i < expression.length(); i++) {
            char cur = expression.charAt(i);
            if (cur == '*' || cur == '+' || cur == '-') {
                num.add(Long.parseLong(tmp));
                tmp = "";
                op.add(cur);
            } else {
                tmp += cur;
            }
        }
        num.add(Long.parseLong(tmp));

        String[] opPriority = {"*+-", "*-+", "+*-", "+-*", "-*+", "-+*"};

        long answer = 0;
        for (int i = 0; i < opPriority.length; i++) {
            answer = Math.max(answer, Math.abs(calculate(opPriority[i], num, op)));
        }
        return answer;
    }

    public static long calculate(String opPriority, ArrayList<Long> num, ArrayList<Character> op) {

        ArrayList<Long> nums = new ArrayList<>(num);
        ArrayList<Character> ops = new ArrayList<>(op);

        for (char c : opPriority.toCharArray()) {
            for (int i = 0; i < ops.size(); ) {
                char curOp = ops.get(i);
                if (curOp != c) {
                    i++;
                    continue;
                }

                if (curOp == '*') nums.set(i, nums.get(i)*nums.get(i+1));
                else if (curOp == '+') nums.set(i, nums.get(i)+nums.get(i+1));
                else if (curOp == '-') nums.set(i, nums.get(i)-nums.get(i+1));

                nums.remove(i+1);
                ops.remove(i);
            }
        }

        return nums.get(0);
    }
}
