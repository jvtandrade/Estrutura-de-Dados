#include<stdio.h>
#include<stdlib.h>

struct no {
    int info;         
    struct no * prox;
};

struct no * novoNo(int info) {
    struct no * novo = malloc(sizeof(struct no));
    novo->info = info;
    return novo;
}

struct no * insert_first(struct no * lista, int info) {
    struct no *novo = novoNo(info);
    if (!novo) return lista;   // se falhar, mantém a lista como estava
    novo->prox = lista;        // novo aponta para a antiga cabeça
    return novo;               // novo vira a cabeça
}

void insert_last(struct no * lista, int info) {
    struct no *novo = novoNo(info);
    // Precisamos encontrar o último elemento da lista. Quando encontramos, adicionamos o novo!
    struct no *curr = lista;
    while (curr->prox != NULL) {
        curr = curr->prox;
    }
    curr->prox = novo;
}

void print_list(struct no *lista) {
    struct no *curr = lista; //ponteiro auxiliar começa apontando pro primeiro nó da lista

    while (curr != NULL) { //enquanto ainda existir nó 
        printf("%d ", curr->info); //imprime o valor do nó que foi armazenado no "info"
        curr = curr->prox; //vai pro próximo nó
    }
    printf("\n");
}

struct no * remove_first(struct no * lista) {
    if (lista == NULL) return NULL; // lista vazia

    struct no *novo_inicio = lista->prox;
    return novo_inicio;
}

int main() {
    struct no *lista = novoNo(1); 
    insert_last(lista, 2);
    insert_last(lista, 3);
    
    print_list(lista); //imprime todos os elementos da lista
    return 0;
}