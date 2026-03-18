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

struct no * remove_first(struct no * lista) {
    if (lista == NULL) return NULL; // lista vazia

    struct no *novo_inicio = lista->prox;
    return novo_inicio;
}

void print_list(struct no *lista) {
    struct no *curr = lista; //ponteiro auxiliar começa apontando pro primeiro nó da lista

    while (curr != NULL) { //enquanto ainda existir nó ou enquanto o auxiliar foi diferente de nulo...
        printf("%d ", curr->info); //imprime o valor do nó que foi armazenado no "info"
        curr = curr->prox; //vai para o próximo nó
    }
    printf("\n");
}

struct no *remove_last(struct no *lista) {

    if (lista == NULL) // lista vazia
        return NULL;

    if (lista->prox == NULL) { // apenas um nó
        free(lista);           // apaga nó
        return NULL;           // lista fica vazia
    }

    struct no *curr = lista; // começa no início
    while (curr->prox->prox != NULL) { // vai até o penúltimo
        curr = curr->prox;     // vai pro próximo
    }

    free(curr->prox);          // remove último
    curr->prox = NULL;         // corta ligação
    return lista;
}

int main() {
    struct no *lista = novoNo(10);
    lista->prox = novoNo(20);
    lista->prox->prox = novoNo(30);

    lista = remove_last(lista);

    print_list(lista);

    return 0;
}