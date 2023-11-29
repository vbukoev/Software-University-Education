#include <stdio.h>

#define N 3 // ��������� ���������� �� N ������ �������

void printCondition() {
    printf("������� �� ��������:\n");
    printf("�� �� ������� �������� �� ��������� �� ������ A[N,N], ������ ������� �� ������ ����� � ��������� [-1000;1000].\n");
}

void printAuthor() {
    printf("����� �� ����������: [������ ��������]\n");
}

void inputArray(float A[N][N]) {
    printf("�������� ���������� �� ������ A[%d][%d]:\n", N, N);
    for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; j++) {
            scanf("%f", &A[i][j]);
        }
    }
}

void printArray(float A[N][N]) { // ����������� �� �������� ����� 
    printf("������ ����� - ����� A[%d][%d]:\n", N, N);
    for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; j++) {
            printf("%.2f\t", A[i][j]);
        }
        printf("\n");
    }
}

void processArray(float A[N][N], float C[], float K, float L) {
    int count = 0;

    // ���������� �� ��������� ����� C
    for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; j++) {
            if (A[i][j] >= K && A[i][j] <= L) {
                C[count++] = A[i][j];
            }
        }
    }

    // ��������� �� ����� C �� �������� 
    for (int i = 0; i < count - 1; i++) {
        for (int j = 0; j < count - i - 1; j++) {
            if (C[j] > C[j + 1]) {
                float temp = C[j]; //������ �� �������� ����������, ����� �� ����� ���������� �� C [j+1], �� ������������ ����� ���������� C[j]
                C[j] = C[j + 1];
                C[j + 1] = temp;
            }
        }
    }
}

void printResults(float C[], int size) {
    printf("��������� ���� ���������:\n");

    // ����� �� ����� C
    printf("����� C:\n");
    for (int i = 0; i < size; i++) {
        printf("%.2f\t", C[i]);
    }
    printf("\n");
}

int main() { // main ���������, � ����� �� ��������� ��������� �������� � �� �������� ��������, ����� �� �������������� ��-����
    float A[N][N];
    float K, L;

    printCondition();
    printAuthor();

    inputArray(A);
    printArray(A);//��������� �� ��������� �������� ����� 

    printf("�������� ��������� [� - L]: ");
    scanf("%f %f", &K, &L);

    float C[N * N]; // ������������, �� C ���� �� ������� ������ �������� �� N*N

    processArray(A, C, K, L);
    printResults(C, N * N);// ���������� �����������

    return 0;
}