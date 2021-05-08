import React from 'react';
import {
  StyleSheet,
  Text,
  Image,
  View,
  ScrollView,
  FlatList,
} from 'react-native';

import DetailsShowButton from './../../components/DetailsShowButton';

export default function Details(props){
    //console.log(props.route.params.data.imageLink)
    const data = props.route.params.data
    //console.log(data.curiosidades[0])
    return (
        <View style={styles.container}>
          <View style={{flex: 0.5}}>
            <Image style={styles.itemimage} source={data.imageLink}>                
            </Image>
          </View>
          
          <View style={{flex:0.5}}>
            
            <ScrollView>
              <View style={{backgroundColor:'white',}}>
                <Text style={styles.title}>Informações Básicas</Text>            
              </View>

              <View style={{flex:1, flexDirection:'column', justifyContent:'space-between', flexWrap: 'wrap'}}>
                <DetailsShowButton name="Ordem Orbital" value={data.informacoesBasicas.ordemOrbital}/>
                <DetailsShowButton name="Distância Do Sol" value={data.informacoesBasicas.distanciaDoSol}/>
                <DetailsShowButton name="Massa" value={data.informacoesBasicas.massa}/>
                <DetailsShowButton name="Volume" value={data.informacoesBasicas.volume}/>
                <DetailsShowButton name="Densidade" value={data.informacoesBasicas.densidade}/>
                <DetailsShowButton name="Área da Superfície" value={data.informacoesBasicas.areaDaSuperficie}/>
                <DetailsShowButton name="Temperatura" value={data.informacoesBasicas.temperatura}/>
                <DetailsShowButton name="Período de Rotação" value={data.informacoesBasicas.periodoDeRotacao}/>
                <DetailsShowButton name="Período De Revolução" value={data.informacoesBasicas.periodoDeRevolucao}/>
                <DetailsShowButton name="Gravidade" value={data.informacoesBasicas.gravidade}/>
                <DetailsShowButton name="Velocidade De Escape" value={data.informacoesBasicas.velocidadeDeEscape}/>
                <DetailsShowButton name="Satélites" value={data.informacoesBasicas.satelites}/>
              </View>

              <View style={{backgroundColor:'white',}}>
                <Text style={styles.title}>Curiosidades</Text>            
              </View>

              <View>
                <FlatList 
                  data={data.curiosidades}
                  keyExtractor={ item=> item.id}
                  scrollEnabled={false}
                  showsVerticalScrollIndicator={false}
                  //renderItem={TopiItem}
                  renderItem = {({item,index}) =>(
                    <View>
                      <Text style={{color: 'white'}}>{index+1}. {item.titulo}</Text>
                      <Text style={{color: 'white'}}>{item.historia}</Text>
                    </View>
                  )}
                >
                </FlatList>
              </View>
            </ScrollView>

          </View>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor:'red',
      flexDirection: 'column',
      backgroundColor: 'black',
    },
    itemimage: {
      width:'100%',
      height: 200,
      flexGrow: 1,
      opacity: 0.9,
      borderRadius: 40,
      borderTopLeftRadius: 0,
      borderTopRightRadius: 0,
    },
    title: {
      color:'black', 
      fontSize:25,
      textAlign:'center',
    }

  });
