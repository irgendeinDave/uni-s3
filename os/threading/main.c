#include <stdio.h>
#include <pthread.h>

void *computation() {
  for (int i = 0; i < 1000; i++) {
      printf("Computing %d\n", i);
  }
}

int main(int argc, char **argv) {
  pthread_t t, t2;
  pthread_create(&t, NULL, computation, NULL);
  pthread_create(&t2, NULL, computation, NULL);
  printf("Thread created\n");
  pthread_join(t, NULL);
  printf("Thread 1 joined\n");
  pthread_join(t2, NULL);
  printf("Thread 2 joined\n");
  return 0;
}