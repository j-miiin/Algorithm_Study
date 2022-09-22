package kakao_blind_recruitment_2020;

// 2020 카카오 블라인드 채용 - 괄호 변환
// https://school.programmers.co.kr/learn/courses/30/lessons/60058

import java.util.Stack;

public class Lv2_change_parenthesis {
    public static void main(String[] args) {
        String p = "(()())()";

        System.out.println(solution(p));
    }

    public static String solution(String p) {

        if (p.equals("")) return "";
        if (checkRightParenthesis(p)) return p;

        String answer = splitString(p);
        return answer;
    }

    public static String splitString(String p) {

        if (checkRightParenthesis(p)) return p;

        String u = "";
        String v = "";
        for (int i = 0; i < p.length(); i++) {
            u += p.charAt(i);
            if (checkBalancedParenthesis(u)) {
                if (i != p.length()-1) v += p.substring(i+1);
                break;
            }
        }

        if (checkRightParenthesis(u)) {
            u += splitString(v);
        } else {
            String tmp = "(";
            tmp += splitString(v);
            tmp += ")";
            u = u.substring(1, u.length()-1);
            tmp += reverseParenthesis(u);
            return tmp;
        }

        return u;
    }

    public static boolean checkBalancedParenthesis(String p) {

        int open = 0, close = 0;
        for (int i = 0; i < p.length(); i++) {
            if (p.charAt(i) == '(') open++;
            else close++;
        }

        return (open == close) ? true : false;
    }

    public static boolean checkRightParenthesis(String p) {
        Stack<Character> stack = new Stack<>();

        for (int i = 0; i < p.length(); i++) {
            if (p.charAt(i) == '(') stack.push('(');
            else {
                if (stack.size() == 0) return false;
                else stack.pop();
            }
        }

        return true;
    }

    public static String reverseParenthesis(String u) {
        String result = "";
        for (int i = 0; i < u.length(); i++) {
            if (u.charAt(i) == '(') result += ')';
            else result += '(';
        }
        return result;
    }
}
