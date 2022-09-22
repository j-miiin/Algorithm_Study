package kakao_blind_recruitment_2020;

// 2020 카카오 블라인드 채용 - 문자열 압축
// https://school.programmers.co.kr/learn/courses/30/lessons/60057

public class Lv2_compress_string {
    public static void main(String[] args) {

        String s = "a";
        System.out.println(solution(s));
    }

    public static int solution(String s) {

        if (s.length() == 1) return 1;

        int answer = Integer.MAX_VALUE;

        for (int i = 1; i < s.length(); i++) {
            String[] arr = splitString(s, i);
            int count = 1;
            String result = "";
            for (int j = 0; j < arr.length-1; j++) {
                 if (arr[j].equals(arr[j+1])) {
                     count++;
                     if (j == arr.length-2) {
                         result += count;
                         result += arr[j];
                     }
                 } else {
                     if (count > 1) {
                         result += count;
                         count = 1;
                     }
                     result += arr[j];
                     if (j == arr.length-2) result += arr[j+1];

                 }
            }

            answer = Math.min(answer, result.length());
        }
        return answer;
    }

    public static String[] splitString(String s, int length) {
        int size;
        if (s.length()%length == 0) size = s.length()/length;
        else size = s.length()/length+1;

        String[] arr = new String[size];
        int idx = 0;
        for (int i = 0; i < s.length(); i+=length, idx++) {
            if (i+length > s.length()) {
                arr[idx] = s.substring(i);
                break;
            }
            arr[idx] = s.substring(i, i+length);
        }
        return arr;
    }
}
